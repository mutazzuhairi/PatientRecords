using PatientRecords.BLLayer.EntityDTOs;
using PatientRecords.Web.WebUtilities.Abstractions;
using System;
using PatientRecords.BLLayer.EntityViews;
using PatientRecords.BLLayer.QueryServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using System.Collections.Generic;

namespace PatientRecords.Web.Controllers.Basics.Views
{
     
    public class PatientRecordViewController : CustomBaseViewController<PatientRecordDTO, PatientRecordView, IPatientRecordQueryService>
    {

        private readonly Lazy<IPatientRecordQueryService> _entityQueryService;
        public PatientRecordViewController(Lazy<IPatientRecordQueryService> entityQueryService) :
            base(entityQueryService)
        {
            _entityQueryService = entityQueryService;
        }


        [HttpGet("AllForPatientId")]
        public virtual async Task<ActionResult<PagedResponse<List<PatientRecordView>>>> GetAllForPatient([FromQuery] PaginationFilter filter, int patientId)
        {
            string route = Request.Path.Value;
            PagedResponse<List<PatientRecordView>> tEntityViews = await _entityQueryService.Value.GetAllForPatientId(filter, route, patientId);
            return Ok(new Response<PagedResponse<List<PatientRecordView>>>(tEntityViews));

        }

    }
}
