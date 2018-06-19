﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace QuickIdentityServer
{
    public class Startup
    {

        /*
         AddIdentityServer方法在依赖注入系统中注册IdentityServer，它还会注册一个基于内存存储的运行时状态，这对于开发场景非常有用，对于生产场景，您需要一个持久化或共享存储，如数据库或缓存。请查看使用EntityFramework Core实现的存储。

AddDeveloperSigningCredential(1.1为AddTemporarySigningCredential)扩展在每次启动时，为令牌签名创建了一个临时密钥。在生成环境需要一个持久化的密钥。详细请点击
             
             */



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //IdentityServer使用通常的模式来配置和添加服务到ASP.NET Core Host
            //
            //在ConfigureServices中，所有必须的服务被配置并且添加到依赖注入系统中。
            
            services.AddIdentityServer().AddDeveloperSigningCredential();
        }




        //在Configure中，中间件被添加到HTTP管道中。
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}