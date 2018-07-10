using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Phoenix.API
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
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = (ctx) =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            (ctx.Response.StatusCode == 200 || ctx.Response.StatusCode == 30))
                        {
                            ctx.Response.StatusCode = 401;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<PhoenixDbContext>();

            services.AddDbContext<PhoenixDbContext>(options =>
                options.UseSqlServer(
                        @"Server=brockenterprise.database.windows.net;Database=Phoenix;user id=brock_dbadmin;password=F1r3St@rter")
                    .UseLazyLoadingProxies());
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("version1", new Info {Title = "Time Capture API", Version = "1.0"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(
                c => { c.SwaggerEndpoint("/swagger/version1/swagger.json", "Time Capture API Version 1"); });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
