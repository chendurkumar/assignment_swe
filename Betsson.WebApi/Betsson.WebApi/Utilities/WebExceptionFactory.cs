using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;

namespace Betsson.WebApi.Utilities
{
    public static class WebExceptionFactory
    {
        private static readonly ILog Log = LogManager.GetLogger("Exception");
        internal static HttpResponseException GetUnauthorizedError(string msg, Exception ex = null)
        {
            return GetHttpResponseException(msg, ex, HttpStatusCode.Unauthorized);
        }

        internal static HttpResponseException GetBadRequestError(string msg, Exception ex = null)
        {
            return GetHttpResponseException(msg, ex, HttpStatusCode.BadRequest);
        }

        internal static HttpResponseException GetServerError(string msg, Exception ex = null)
        {
            return GetHttpResponseException(msg, ex, HttpStatusCode.InternalServerError);
        }

        internal static HttpResponseException GetNotFoundError(string msg, Exception ex = null)
        {
            return GetHttpResponseException(msg, ex, HttpStatusCode.NotFound);
        }


        private static HttpResponseException GetHttpResponseException(string msg, Exception ex, HttpStatusCode code)
        {
            msg = msg.Replace("\r", string.Empty).Replace("\n", string.Empty);
            var response = new HttpResponseMessage { StatusCode = code };
            var innerExceptionMsg = ex?.Message ?? "";
            response.ReasonPhrase = $"Error : {msg}, Inner Exception message {innerExceptionMsg}";
            Log.Error(msg, ex);
            return new HttpResponseException(response);
        }
    }
}