

using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using IdentityServer4.Configuration;

#pragma warning disable 1591

namespace IdentityServer4.Hosting
{
    public class BaseUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IdentityServerOptions _options;

        public BaseUrlMiddleware(RequestDelegate next, IdentityServerOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            context.SetIdentityServerBasePath(request.PathBase.Value.RemoveTrailingSlash());
            AuditLog auditLog = new AuditLog();
            auditLog.Url = context.Request.Path;
            auditLog.CorrelationId = context.Connection.Id;
            auditLog.HttpMethod = context.Request.Method;
            await HttpContextLogHandler.LogAsync(auditLog);
            await _next(context);
        }
    }
}