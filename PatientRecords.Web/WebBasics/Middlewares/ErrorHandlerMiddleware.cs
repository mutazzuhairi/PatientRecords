using Microsoft.AspNetCore.Http;
using PatientRecords.BLLayer.BLBasics.HelperServices;
using PatientRecords.Web.WebBasics.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientRecords.Web.WebBasics.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private  Lazy<IApiExceptionBuilder> _iApiExceptionBuildercs;
        private  Lazy<ITransactionFactory> _iTransactionFactory;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, Lazy<IApiExceptionBuilder> apiExceptionBuildercs , Lazy<ITransactionFactory>  iTransactionFactory)
        {
            try
            {
                _iApiExceptionBuildercs = apiExceptionBuildercs;
                _iTransactionFactory = iTransactionFactory;
                using TransactionScope scope = _iTransactionFactory.Value.GetAsyncTransaction();
                await _next(context);
                scope.Complete();
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                setResponseStatusCode(response, error);
                var result = JsonSerializer.Serialize(_iApiExceptionBuildercs.Value.BuildException(error));
                await response.WriteAsync(result);
            }
        }


        private void setResponseStatusCode(HttpResponse response, Exception error)
        {
            switch (error)
            {
                case AppException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }
    }
}
