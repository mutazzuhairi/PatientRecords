using Microsoft.AspNetCore.Mvc.ModelBinding;
using PatientRecords.Web.WebBasics.BasicServices.Interfaces;
using System;
 

namespace PatientRecords.Web.WebBasics.BasicServices 
{
    public class ApiExceptionBuilder: IApiExceptionBuildercs
    {
        public  APIException BuildException(Exception ex)
        {

            APIException apiException;

            string errorMessage = ex.Message + Environment.NewLine;
            string shortErrorMessage = ex.Message + Environment.NewLine;
            if (ex.InnerException != null)
            {

                errorMessage = errorMessage + " (" + (ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.InnerException.Message) + ")" + Environment.NewLine;
                shortErrorMessage = shortErrorMessage + " (" + (ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.InnerException.Message) + ")" + Environment.NewLine;
            }

            apiException = new APIException()
            {
                ErrorType = ex.GetType().Name,
                ErrorMessage = errorMessage,
                ShortErrorMessage = shortErrorMessage
            };



            return apiException;
        }


        public  APIException BuildModelException(ModelStateDictionary modelState)
        {
            APIException apiException;
            string errorMessage = "";
            string shortErrorMessage = "";

            foreach (var modValue in modelState.Values)
            {
                foreach (var error in modValue.Errors)
                {
                    errorMessage += error.ErrorMessage + Environment.NewLine;
                    shortErrorMessage += error.ErrorMessage + Environment.NewLine;
                }
            }

            apiException = new APIException()
            {
                ErrorType = "ModelStateError",
                ErrorMessage = errorMessage,
                ShortErrorMessage = shortErrorMessage,
            };

            return apiException;
        }
    }
}
