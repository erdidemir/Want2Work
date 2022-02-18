using DoDo.Api.Extensions;
using DoDo.Application;
using DoDo.Application.Models.Settings;
using DoDo.Domain.Entities.Authentications;
using DoDo.Infrastructure;
using DoDo.Infrastructure.Contracts.Persistence;
using DoDo.Infrastructure.MiddleWares.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

namespace DoDo.Api
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
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);

            #region Settings

            services.Configure<JwtSettings>(Configuration.GetSection("JWT"));
            var jwt = Configuration.GetSection("JWT").Get<JwtSettings>();

            services.Configure<CacheConfiguration>(Configuration.GetSection("CacheConfiguration"));

            #endregion

            services.AddMemoryCache();

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
               .AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultTokenProviders();

            services.ConfigureCors();

            services.AddControllers();

            #region JWT 
           
            services.AddAuth(jwt);

            #endregion

            #region Swagger 
            string version = "v1";
            services.AddSwaggerGen(gen =>
            {
                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Jwt Bearer Token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    },
                };

                gen.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = "Want2Work Wep Api",
                    Version = version,
                    License = new OpenApiLicense
                    {
                        Name = "Powered by Want2Work",
                        Url = new Uri("https://wantowork.de/"),
                    },
                    Contact = new OpenApiContact
                    {
                        Name = "Erdi Demir",
                        Email = "erdi.demir@erdidemir.com.tr"
                    }
                });

                gen.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                gen.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
                gen.UseAllOfToExtendReferenceSchemas();
                gen.IncludeXmlCommentsFromInheritDocs(includeRemarks: true, excludedTypes: typeof(string));
                gen.AddEnumsWithValuesFixFilters(services, o =>
                {
                    // add schema filter to fix enums (add 'x-enumNames' for NSwag) in schema
                    o.ApplySchemaFilter = true;

                    // add parameter filter to fix enums (add 'x-enumNames' for NSwag) in schema parameters
                    o.ApplyParameterFilter = true;

                    // add document filter to fix enums displaying in swagger document
                    o.ApplyDocumentFilter = true;

                    // add descriptions from DescriptionAttribute or xml-comments to fix enums (add 'x-enumDescriptions' for schema extensions) for applied filters
                    o.IncludeDescriptions = true;

                    // add remarks for descriptions from xml-comments
                    o.IncludeXEnumRemarks = true;

                    // get descriptions from DescriptionAttribute then from xml-comments
                    o.DescriptionSource = DescriptionSources.DescriptionAttributesThenXmlComments;


                });
            });



            #endregion

            #region Authorization

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
            });

            #endregion

            #region ExternalLogin

            //services.AddAuthentication().
            //    AddGoogle(x =>
            //    {
            //        x.ClientId = Configuration.GetValue<string>("Secrets:GoogleClientId");
            //        x.ClientId = Configuration.GetValue<string>("Secrets:GoogleClientId");

            //    });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoDo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
