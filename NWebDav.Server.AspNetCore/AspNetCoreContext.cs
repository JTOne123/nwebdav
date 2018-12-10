﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using NWebDav.Server.Http;

namespace NWebDav.Server.AspNetCore
{
    public partial class AspNetCoreContext : IHttpContext
    {
        public AspNetCoreContext(HttpContext httpContext, CancellationToken cancellationToken)
        {
            // Make sure a valid HTTP context is specified
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            // Save request, response and session
            Request = new AspNetCoreRequest(httpContext.Request, cancellationToken);
            Response = new AspNetCoreResponse(httpContext.Response);
            Session = new AspNetCoreSession(httpContext.User);
        }

        public IHttpRequest Request { get; }
        public IHttpResponse Response { get; }
        public IHttpSession Session { get; }

        public Task CloseAsync()
        {
            // Context is closed automatically
            return Task.FromResult(true);
        }
    }
}
