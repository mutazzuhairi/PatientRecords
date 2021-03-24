using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatientRecords.BLLayer.BLBasics.HelperClasses;

namespace PatientRecords.BLLayer.BLBasics.HelperServices.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
