using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Chat;
using Application;
using ApplicationUser;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Microsoft.AspNetCore.SignalR;
using Matching;
using Microsoft.Extensions.FileProviders;

namespace Tindyr
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment HostEnvironment;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////for js to call on backend
            services.AddCors(options => options.AddPolicy("CorsPolicy",
             builder =>
             {
                 builder.AllowAnyMethod().AllowAnyHeader()
                        .WithOrigins("https://tindyr.azurewebsites.net")
                        .AllowCredentials();
             }));
            //every layer of the project, Application, ApplicationUser etc has a dependency injection extension of Services, we use that here to add all dependencies we need for these layers and to initialize/use them.
            //the mediator pattern, we first init the dependency injection 'helper'
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //the business logic and all its dependencies
            services.AddApplication();
            //db and its dependencies
            services.AddPersistence(Configuration);
            //MVC 
            services.AddControllersWithViews();
            //for http requests
            services.AddHttpContextAccessor();
            //add cookies support (for session info)
            # region cookies policy
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #endregion
            //add AppllicationUser - anything user log in out etc - and its dependencies
            services.AddApplicationUser();

            // Register the Swagger services - curently not working - we use swagger to hide backend and expose only API calls to it so front end can do whatever it wants without affecting the backend
            //theoretically, with this, we may not even need MVC, but we will skip Swagger in future versions :)
            services.AddSwaggerDocument();
            //add realtime app 
            services.AddSignalR();
            //add chat
            services.AddAppChat(Configuration);
            services.AddLiveMatch();

            //#region file provider setup
            //var physicalProvider = HostEnvironment.ContentRootFileProvider;
            //var manifestEmbeddedProvider =
            //    new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
            //var compositeProvider =
            //    new CompositeFileProvider(physicalProvider, manifestEmbeddedProvider);

            //services.AddSingleton<IFileProvider>(compositeProvider);
            //#endregion
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //
            app.UseCookiePolicy();
            //auth by cookies&&Identity
            app.UseAuthentication();

            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<AppChat>("/appchat");//add chat
                endpoints.MapHub<LiveMatch>("/livematch");//add live match
                //endpoints.MapAreaControllerRoute(
                //    name: "Auth",
                //    areaName: "Auth",
                //    pattern: "Auth/{controller=Auth}/{action=LogIn}/{id?}"
                //    );
            });


        }
    }
}
