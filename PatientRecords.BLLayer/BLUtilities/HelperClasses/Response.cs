using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.BLLayer.BLUtilities.HelperClasses
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Succeeded = true;
            ErrorMessage = string.Empty;
            ErrorType = null;
            ShortErrorMessage = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string  ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public string ShortErrorMessage { get; set; }

    }
}
