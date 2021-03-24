using Microsoft.AspNetCore.Mvc.ModelBinding;
using PatientRecords.BLLayer.BLBasics.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Web.WebBasics.HelperServices.Interfaces
{
    public interface IApiExceptionBuilder
    {
        public Response<object> BuildException(Exception ex);
     }
}
