using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CommenReactProjectAPI.Middleware
{
      public class OAuthMiddleware
      {
            private readonly RequestDelegate _next;
            private const string apiUsername = "ApiUsername";
            private const string apiPassword = "ApiPassword";
            public OAuthMiddleware(RequestDelegate next )
            {
                  _next = next;
            }

            public async Task Invoke(HttpContext httpContext)
            {
                  //Get the Authorization username and password encrypted format.
                  var authHeader = httpContext.Request.Headers["Authorization"].ToString();

                  //Checking if the key is starting with Base keyword or not.
                  if(authHeader != null && authHeader.StartsWith("Basic"))
                  {
                        //Split the value with basic
                        string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();

                        //decode the base64value
                        Encoding encoding = Encoding.UTF8;
                        string decodedUsernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                        //Split it with :
                        int index = decodedUsernamePassword.IndexOf(":");

                        //We will get username and password
                        var username = decodedUsernamePassword.Substring(0 , index);
                        var password = decodedUsernamePassword.Substring(index + 1);

                        //Getting Username and password from appsettings.json file
                        var appSettings = httpContext.RequestServices.GetRequiredService<IConfiguration>();
                        var usernameConfige = appSettings.GetValue<string>(apiUsername);
                        var passwordConfige = appSettings.GetValue<string>(apiPassword);

                        //Compare appsettings.json file Username, password with Header Username and Password which is passed by user.
                        if(username.Equals(usernameConfige) && password.Equals(passwordConfige))
                        {
                              await _next.Invoke(httpContext);
                        }
                        else
                        {
                              httpContext.Response.StatusCode = 401;
                              await httpContext.Response.WriteAsync("Invalid username.");
                        }
                  }
                  else
                  {
                        httpContext.Response.StatusCode = 401;
                        await httpContext.Response.WriteAsync("Authorization is not given.");
                  }
                  return;
            }
      }
}