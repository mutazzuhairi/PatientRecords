using PatientRecords.BLLayer.BLUtilities.HelperClasses;
using PatientRecords.Web.WebUtilities.HelperServices.Interfaces;
using System;
 

namespace PatientRecords.Web.WebUtilities.HelperServices 
{
    public class ApiExceptionBuilder: IApiExceptionBuilder
    {
        public Response<object> BuildException(Exception ex)
        {
 
            string errorMessage = ex.Message + Environment.NewLine;
            if (ex.InnerException != null)
            {

                errorMessage = errorMessage + " (" + (ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.InnerException.Message) + ")" + Environment.NewLine;
            }

            Response<object> response = new Response<object>()
            {
                Succeeded = false,
                Data  =null,
                ErrorType = ex.GetType().Name,
                ErrorMessage = errorMessage,
            };
 
            return response;
        }

 
    }
}
