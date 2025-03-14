using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json.Serialization;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CommenReactProjectAPI.Model;

namespace CommenReactProjectAPI.Middleware
{
      public class ExceptionMiddleware
      {
            private readonly RequestDelegate _next;
            public ExceptionMiddleware(RequestDelegate next)
            {
                  _next = next;
            }
            public async Task InvokeAsync(HttpContext httpContext)
            {
                  try
                  {
                        await _next(httpContext);
                  }
                  catch(Exception ex)
                  {
                        await HandleExceptionAsync(httpContext , ex);
                  }
            }
            private async Task HandleExceptionAsync(HttpContext context , Exception exception)
            {
                  context.Response.ContentType = "application/json";
                  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                  await context.Response.WriteAsync(new ErrorDetails()
                  {
                        StatusCode = context.Response.StatusCode ,
                        Message = exception.Message
                  }.ToString());
            }
      }
}
