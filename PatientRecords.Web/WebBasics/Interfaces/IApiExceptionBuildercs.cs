using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Web.WebBasics.Interfaces
{
    public interface IApiExceptionBuildercs
    {
        public  APIException BuildException(Exception ex);
        public  APIException BuildModelException(ModelStateDictionary modelState);
    }
}
