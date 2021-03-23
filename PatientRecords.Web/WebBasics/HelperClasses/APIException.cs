using System.Collections.Generic;

namespace PatientRecords.Web.WebBasics
{
    public class APIException
    {
        public string ErrorType { get; set; }
        public string ShortErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Errors { get; set; }
    }
}
