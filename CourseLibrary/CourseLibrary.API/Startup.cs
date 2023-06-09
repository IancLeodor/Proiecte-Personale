using AutoMapper;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace CourseLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();// accepta o actiune pentru a o configura 
            //services.AddControllers();
            //setupAction =>
            // {
            //  setupAction.ReturnHttpNotAcceptable = true;
            // setupAction.Output Formatters.Add(
            //new XmlDataContractSerializerOutput Formatter());
            // }).AddXmlDataContractSerializerFormatters();
            services.AddControllers(
            setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                //setupAction.Output Formatters.Add(
                //new XmlDataContractSerializerOutput Formatter());
            })//.AddXmlDataContractSerializerFormatters()//asigura suportul de formatare de intrare si iesire pentru XML
            .AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            })
             .ConfigureApiBehaviorOptions(setupAction =>  //aceasta va fi executata cand starea modelului este invalida 
             {
                 setupAction.InvalidModelStateResponseFactory = context =>
                 {
                     // create a problem details object
                     var problemDetailsFactory = context.HttpContext.RequestServices
                         .GetRequiredService<ProblemDetailsFactory>();
                     var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                             context.HttpContext,
                             context.ModelState);

                     // add additional info not added by default
                     problemDetails.Detail = "See the errors field for details.";
                     problemDetails.Instance = context.HttpContext.Request.Path;

                     // find out which status code to use
                     var actionExecutingContext =
                           context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

                     // if there are modelstate errors & all keys were correctly
                     // found/parsed we're dealing with validation errors
                     if ((context.ModelState.ErrorCount > 0) &&
                         (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                     {
                         problemDetails.Type = "https://courselibrary.com/modelvalidationproblem";
                         problemDetails.Status = StatusCodes.Status422UnprocessableEntity;////daca au fost argumente si nu au putut fi analizate este returnat o cerere gresita ca si pana acum
                         problemDetails.Title = "One or more validation errors occurred.";

                         return new UnprocessableEntityObjectResult(problemDetails)
                         {
                             ContentTypes = { "application/problem+json" }
                         };
                     }

                     // if one of the keys wasn't correctly found / couldn't be parsed
                     // we're dealing with null/unparsable input
                     problemDetails.Status = StatusCodes.Status400BadRequest;
                     problemDetails.Title = "One or more errors on input occurred.";
                     return new BadRequestObjectResult(problemDetails)
                     {
                         ContentTypes = { "application/problem+json" }
                     };
                 };
             });
             //setupAction.ReturnHttpNotAcceptable = true;
            //setupAction.Output Formatters.Add(
            //new XmlDataContractSerializerOutput Formatter());
            // }).AddXmlDataContractSerializerFormatters();//asigura suportul de formatare de intrare si iesire pentru XML
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // incarcam profiluri din tpate ansamblurile din domeniul curent 
            services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();

            services.AddDbContext<CourseLibraryContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=CourseLibraryDB;Trusted_Connection=True;");
            }); 
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder=>
                {  
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again 1ater.");
                    });
                });
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
