using System;
using System.Net;

using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspNet5FileUploadFileTable
{
    using Microsoft.AspNet.Mvc;

    public class ValidateMimeMultipartContentFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ValidateMimeMultipartContentFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ctor ValidateMimeMultipartContentFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogWarning("ClassFilter OnActionExecuting");

            if (!IsMultipartContentType(context.HttpContext.Request.ContentType))
            {
                context.Result = new HttpStatusCodeResult(415);
                return;
            }

            base.OnActionExecuting(context);
        }

        private static bool IsMultipartContentType(string contentType)
        {
            return !string.IsNullOrEmpty(contentType) && contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
