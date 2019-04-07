using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BISM.OS.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();

            Common.BaseConfig.SetBaseConfig(Configuration, env.ContentRootPath, env.WebRootPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return RegisterAutofac(services);//注册Autofac
        }

        /// <summary>
        /// AutoFac 注册
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            // 实例化Autofac容器
            var builder = new ContainerBuilder();
            // 将Services中的服务填充到Autofac中
            builder.Populate(services);
            // 新模块组件注册    
            builder.RegisterModule<Ioc.AutofacBootStrapper.AutofacModuleRegister>();
            // 创建容器
            var Container = builder.Build();
            // 第三方IOC接管 core内置DI容器 
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
