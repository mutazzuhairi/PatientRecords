using Microsoft.AspNetCore.Mvc.ModelBinding;
using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Web.WebUtilities.HelperServices.Interfaces
{
    public interface IApiExceptionBuilder
    {
        public Response<object> BuildException(Exception ex);
     }
}
