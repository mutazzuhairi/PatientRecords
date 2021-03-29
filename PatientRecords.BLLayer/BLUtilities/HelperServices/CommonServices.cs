using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System.Data;
using System.Threading.Tasks;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;
using System;

namespace PatientRecords.BLLayer.BLUtilities.HelperServices
{
    public class CommonServices : ICommonServices
    {
        private readonly IConfiguration _configuration;
        public CommonServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DataTable> ExecuteSQLQuery(string sqlQuery)
        {
 
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(SystemConstatnts.ConnectionString.PatientRecord);
            SqlDataReader myReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand myCommand = new SqlCommand(sqlQuery, connection))
                {
                    myReader = await myCommand.ExecuteReaderAsync();
                    table.Load(myReader);

                    myReader.Close();
                    connection.Close();
                }
            }

            return table;
        }




        public DateTime? GetQueryDateFilter(string filterName)
        {
            var dateCriteria = DateTime.Now;
            switch (filterName.ToLower())
            {
                case "lastweek":
                    {
                        dateCriteria = dateCriteria.Date.AddDays(-7);
                        break;
                    }
                case "lastmonth":
                    {
                        dateCriteria = dateCriteria.Date.AddMonths(-1);
                        break;
                    }
                case "lastyear":
                    {
                        dateCriteria = dateCriteria.Date.AddYears(-1);
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }
 
            return dateCriteria;
        }



        public bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
