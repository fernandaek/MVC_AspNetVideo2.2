using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore22Intro.Data;
using AspNetCore22Intro.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCore22Intro.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore22Intro
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options => options.UseSqlServer(conn));
            services.AddIdentity<VideoUser, IdentityRole>().AddEntityFrameworkStores<VideoDbContext>();
            services.AddMvc();
            //services.AddSingleton<IMessageService, HardcodedMessageService>();
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
            //services.AddSingleton<IVideoData, MockVideoData>();
            services.AddScoped<IVideoData, SqlVideoData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            //var message = Configuration["Message"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) =>
            {
                //throw new Exception("Fake exception");
                //var message = Configuration["Message"];
                var message = msg.GetMessage();
                await context.Response.WriteAsync(message);
            });
            
        }
    }
}
