using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Movie.Services.Models;

namespace TopMovie
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
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<webphimContext>();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var rewrite = new RewriteOptions()
            //    .AddRewrite(@"movie/(\d+)", "Home/WatchMovie/:id", true);

            //app.UseRewriter(rewrite);

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                var rewrite = new RewriteOptions()
                .AddRewrite(@"movie/(\d+)", "Home/WatchMovie?id=$1", skipRemainingRules: false)
                .AddRewrite(@"contact", "Home/Contact", skipRemainingRules: false)
                .AddRewrite(@"categories", "Home/ListTags?type=Category", skipRemainingRules: false)
                .AddRewrite(@"actresses", "Home/ListTags?type=Actress", skipRemainingRules: false)
                .AddRewrite(@"studios", "Home/ListTags?type=Studio", skipRemainingRules: false)
                .AddRewrite(@"tags", "Home/ListTags?type=Tag", skipRemainingRules: false)
                .AddRewrite(@"tag/(.*)", "Home/Tag?tag=$1", skipRemainingRules: false)
                .AddRewrite(@"category/(.*)", "Home/Category?category=$1", skipRemainingRules: false)
                .AddRewrite(@"actress/(.*)", "Home/Actor?actor=$1", skipRemainingRules: false);


                app.UseRewriter(rewrite);
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
