using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi
{
    public class SampleExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if(actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}