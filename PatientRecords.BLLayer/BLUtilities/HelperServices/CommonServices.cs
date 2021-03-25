using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces;
using System.Data;
using PatientRecords.BLLayer.BLUtilities.SystemConstants;

namespace PatientRecords.BLLayer.BLUtilities.HelperServices
{
    public class CommonServices : ICommonServices
    {
        private readonly IConfiguration _configuration;
        public CommonServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable ExecuteSQLQuery(string sqlQuery)
        {
 
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(SystemConstatnts.ConnectionString.PatientRecord);
            SqlDataReader myReader;
            using (SqlConnection connection = new SqlConnection(sqlDataSource))
            {
                connection.Open();
                using (SqlCommand myCommand = new SqlCommand(sqlQuery, connection))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    connection.Close();
                }
            }

            return table;
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
