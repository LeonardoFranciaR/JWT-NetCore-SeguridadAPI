using JWT_NetCore.Core.Interface;
using JWT_NetCore.Core.Service;
using JWT_NetCore.Services.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace JWT_NetCore.Services
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
            //servicio InformationCreator
            services.
                AddScoped<IInformationCreator, InformationCreatorServices>();

            //Declaramos el tipo de envío de autenticación
            services.
               AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })
               .AddJwtBearer("JwtBearer", jwtOptions =>
               {
                   //Validación de los parámetros
                   jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                   {
                       IssuerSigningKey = TokenController.SIGNING_KEY_NSC,
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.FromMinutes(5)
                   };
               });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
