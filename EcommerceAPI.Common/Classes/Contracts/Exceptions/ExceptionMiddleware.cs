using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace EcommerceAPI.Common.Classes.Contracts.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Método que intercepta toda las peticiones del aplicativo (Middleware)
        /// Si se produce algun error se controlan
        /// </summary>
        /// <param name="httpContext">HttpContext de la aplicación</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Se controla la excepción
                var response = httpContext.Response;
                response.ContentType = "application/json";
                var bodyresponse = "";
                switch (ex)
                {
                    case ArgumentException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        bodyresponse = JsonConvert.SerializeObject(new { StatusCode = (int)HttpStatusCode.NotFound, message = e?.Message, });
                        //SendErrorService(ex, httpContext);
                        break;
                    case System.ComponentModel.DataAnnotations.ValidationException exeption:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                        bodyresponse = JsonConvert.SerializeObject(new { StatusCode = (int)HttpStatusCode.Unauthorized, message = exeption?.Message, });
                        //SendErrorService(ex, httpContext);
                        break;
                    case UnauthorizedAccessException exeption:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        bodyresponse = JsonConvert.SerializeObject(new { StatusCode = (int)HttpStatusCode.Unauthorized, message = exeption?.Message, });
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        bodyresponse = JsonConvert.SerializeObject(new { StatusCode = (int)HttpStatusCode.InternalServerError, message = ex?.Message, });
                        //SendErrorService(ex, httpContext);
                        break;
                }
                await response.WriteAsync(bodyresponse);
            }
        }
    }
}
