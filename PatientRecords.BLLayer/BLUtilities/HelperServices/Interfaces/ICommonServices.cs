using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces
{
    public interface ICommonServices
    {
        public DataTable ExecuteSQLQuery(string sql);
        public bool IsEmailValid(string email);
    }
}
