using CommenReactProjectAPI.IModelRepository;
using CommenReactProjectAPI.Middleware;
using CommenReactProjectAPI.ModelRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommenReactProjectAPI
{
      public class Hello
      {
            public Hello(IConfiguration configuration)
            {
                  Configuration = configuration;
            }
            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                  services.AddCors();
                  services.AddControllers();
                  services.AddSwaggerGen(); //for Swagger UI Injected Swagger Service.
                  services.AddTransient<IDepartmentRepository , DepartmentRepository>();
                  services.AddTransient<IEmployeeRepository , EmployeeRepository>();
                  services.AddTransient<IStudentRepository , StudentRepository>();
                  services.AddTransient<IUserRepository , UserRepository>();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app , IWebHostEnvironment env)
            {
                  if(env.IsDevelopment())
                  {
                        app.UseSwagger();
                        app.UseSwaggerUI(c =>
                        {
                              c.SwaggerEndpoint("/swagger/v1/swagger.json" , "My API V1");
                        });
                  }

                  app.UseCors(x =>
                                          x.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .WithExposedHeaders("*"));

                 app.UseMiddleware<OAuthMiddleware>();

                  app.UseHttpsRedirection();

                  app.UseRouting();

                  app.UseMiddleware<ExceptionMiddleware>();

                  app.UseAuthorization();

                  app.UseEndpoints(endpoints =>
                  {
                        endpoints.MapControllers();
                  });
            }
      }
}
