
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.Web.WebUtilities.Extensions;


namespace PatientRecords.Web.Controllers.Extends.Views
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PatientStatisticController : ControllerBase
    {
 
        private readonly Lazy<ICommonServices> _iCommonServices;

        public PatientStatisticController(Lazy<ICommonServices>  iCommonServices)
        {
            _iCommonServices = iCommonServices;
        }


        [HttpGet("NameAndAge/{id}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> GetNameAndAge(int id)
        {
            string query = string.Format(@"
                                  select Name, FLOOR(DATEDIFF(DAY, DateOfBirth, GETDATE()) / 365.25) AS Age
                                  from dbo.Patients 
                                  where Id ={0}", id);

            var table = await _iCommonServices.Value.ExecuteSQLQuery(query);

            return Ok(new Response<List<Dictionary<string, object>>>(table.ToJson()));  
        }

 

        [HttpGet("AverageOfBillsRemovingOutliers/{id}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> GetAverageOfBillsRemovingOutliers(int id)
        {
            string query = string.Format(@"
                             WITH AvgStd AS (
                                              SELECT
                                              AVG(n.Bill) AS avgnum,
                                              STDEVP(n.Bill) AS stdnum
                                              FROM dbo.PatientRecords AS n   
                                              WHERE n.PatientId={0}
                                             )
                                      SELECT 
                                      AVG(n.Bill) AS AverageOfBills
                                      FROM  dbo.PatientRecords AS n
                                      CROSS JOIN AvgStd
                                      WHERE n.PatientId=120 and n.Bill < (AvgStd.avgnum + 2* AvgStd.stdnum)
                                      AND n.Bill > (AvgStd.avgnum - 2* AvgStd.stdnum)", id);

            var table = await _iCommonServices.Value.ExecuteSQLQuery(query);

            return Ok(new Response<List<Dictionary<string, object>>>(table.ToJson()));
        }


        [HttpGet("AverageOfBills/{id}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> GetAverageOfBills(int id)
        {
            string query = string.Format(@"
                                 select AVG(Bill) AS AverageOfBills 
                                 from PatientRecords 
                                 where PatientId ={0}", id);

            var table = await _iCommonServices.Value.ExecuteSQLQuery(query);

            return Ok(new Response<List<Dictionary<string, object>>>(table.ToJson()));
        }


        [HttpGet("5thRecordEntryOfPatient/{id}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> Get5thRecordEntryOfPatient(int id)
        {
            string query = string.Format(@"
                                  SELECT * FROM (   
                                             SELECT *, ROW_NUMBER() OVER (ORDER BY TimeOfEntry ASC) AS RowNum 
                                             from dbo.PatientRecords 
                                             WHERE PatientId={0}
                                           ) sorty
                                  WHERE RowNum = 5;", id);

            DataTable table = await _iCommonServices.Value.ExecuteSQLQuery(query);
            return Ok(new Response<List<Dictionary<string, object>>>(table.ToJson()));
        }



        [HttpGet("PatientsWithSimilarDiseases/{id}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> GetPatientsWithSimilarDiseases(int id)
        {
            string query = string.Format(@"
                                 SELECT * FROM dbo.Patients WHERE Id IN(
                                 SELECT  PatientId
                                 FROM dbo.PatientRecords  WHERE  ( DiseaseName IN 
                                                                           (SELECT DiseaseName 
								                                            FROM dbo.PatientRecords 
								                                            WHERE  PatientId = {0}) 
								                                            AND  PatientId!=  {0})
                                GROUP BY PatientId 
                                HAVING COUNT(*)>=2
                                 )", id);

            var table = await _iCommonServices.Value.ExecuteSQLQuery(query);
            return Ok(new Response<List<Dictionary<string, object>>>(table.ToJson()));
        }




        [HttpGet("MonthContainsHighestNumberOfVisits/{id}")]
        public async Task<ActionResult<List<Dictionary<string, object>>>> GetMonthContainsHighestNumberOfVisits(int id)
        {
            string query = string.Format(@"
                                SELECT TOP 1 FORMAT(TimeOfEntry, 'MMMM') AS MonthName  
                                FROM dbo.PatientRecords 
                                WHERE PatientId = {0}
                                GROUP BY FORMAT(TimeOfEntry, 'MMMM') 
                                ORDER BY COUNT(1) DESC", id);

            var table = await _iCommonServices.Value.ExecuteSQLQuery(query);
            return Ok(new Response<List<Dictionary<string, object>>>(table.ToJson()));
        }

    }
}
