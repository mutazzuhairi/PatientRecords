using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using System;
 
namespace PatientRecords.Web.WebUtilities.HelperServices.Interfaces
{
    public interface IApiExceptionBuilder
    {
        public Response<object> BuildException(Exception ex);
     }
}
