using Blog.Common.Extensions;
using Blog.Core;
using Blog.Web.Filter;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Blog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();
            //添加Session 服务
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;

            });
            //注册全局异常过滤器
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<ExceptionGlobalFilterAttribute>();
            //});
            services.AddHttpContextHelperAccessor();
            //解决序列化json时字段全部变为小写模式
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //防止汉字被自动编码
            //services.Configure<WebEncoderOptions>(options =>
            //{
            //    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            //});
            //设置认证cookie名称、过期时间、是否允许客户端读取
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "appsoft";//cookie名称
                options.Cookie.Expiration = TimeSpan.FromHours(1);//过期时间
                options.Cookie.HttpOnly = true;//不允许客户端获取
                options.SlidingExpiration = true;// 是否在过期时间过半的时候，自动延期
            });

            #region Autofac注入
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();
            //注册业务逻辑层所在程序集中的所有类的对象实例
            builder.RegisterAssemblyTypes(Assembly.Load("Blog.Services")).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //注册数据仓储层所在程序集中的所有类的对象实例
            builder.RegisterAssemblyTypes(Assembly.Load("Blog.Repository")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.Populate(services);
            //创建一个Autofac的容器
            var container = builder.Build();
            //第三方IOC接管 core内置DI容
            return container.Resolve<IServiceProvider>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //HttpContext扩展
            app.UseHttpContextHelper();

            //登录授权cookie
            app.UseAuthentication();

            #region 解决Ubuntu Nginx 代理不能获取IP问题
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
