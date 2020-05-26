using Core.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var jsonErrorResponse = new ErrorResponse

            {
                Message = "Test an internal error has occurred"
            };

            var BaseResponse = new BaseResponse
            {
                ErrorResponse = jsonErrorResponse
            };

            // Hier exceptions handeln
            var exceptionType = context.Exception.GetType();
            // if exception is ....

            if (_env.IsDevelopment())
            {
                jsonErrorResponse.Exception = context.Exception.ToString();
            }

            context.Result = new ObjectResult(BaseResponse)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
