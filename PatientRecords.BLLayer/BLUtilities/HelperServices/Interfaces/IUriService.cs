using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;

namespace PatientRecords.BLLayer.BLUtilities.HelperServices.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
