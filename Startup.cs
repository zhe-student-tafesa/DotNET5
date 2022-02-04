using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration.Json;

using WebApplication2.Models;
using Autofac;
using Microsoft.Extensions.Configuration.Json;
using Autofac.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebApplication2.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Utility.AutofacExtension;

namespace WebApplication2
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
            #region 解决修改 视图内容，必须 编译后方 可生效的问题
            //1. Nuget 安装Microsoft.aspnetcore.mvc.razor.run
            //2. 配置使用 .AddRazorPages().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            #endregion
            //

            #region IOC注册 抽象与 具体的依赖 关系
                services.AddTransient<ITestServiceA, TestServiceA>();
            #endregion


            #region  Autofac 支持配置文件
            {
                ContainerBuilder containerBuilder1 = new ContainerBuilder();
                // 在这里 写入 Autofac注入
                {
                    IConfigurationBuilder config = new ConfigurationBuilder();//建造者
                    IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
                    {
                        Path = "CfgFile/autofac.json",
                        Optional = false,
                        ReloadOnChange = true
                    };
                    config.Add(autofacJsonConfigSource);// 把 配置 给 建造者
                    ConfigurationModule module = new ConfigurationModule(config.Build());// build一下，保存在module里
                    containerBuilder1.RegisterModule(module); //注册 module
                }
                IContainer container4 = containerBuilder1.Build(); // 注册到 容器（container4）里 
                ITestServiceA testServiceA1 = container4.Resolve<ITestServiceA>();
                testServiceA1.Show();

            }
            #endregion

            //#region  Autofac容器
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>();// 注册  子 --父
            //IContainer container = containerBuilder.Build();//获得 容器
            //ITestServiceA testServiceA=  container.Resolve<ITestServiceA>();// 获取服务
            //testServiceA.Show();//使用
            //#endregion

            #region 指定用autofac容器去生成 控制器实例
            //即用ServiceBasedControllerActivator取代 IControllerActivator
            services.Replace(ServiceDescriptor.Transient<IControllerActivator,
                ServiceBasedControllerActivator>());
            #endregion


            //DbConnectionOptions  写在泛型里                  获取配置文件里这个节点的数据ConnectionStrings
            services.Configure<Models.DbConnectionOptions>(Configuration.GetSection("ConnectionStrings"));
            services.AddControllersWithViews();
            services.AddSession();// 添加 session 服务 1

            //读取配置文件
            Console.WriteLine($"Id:{Configuration["Id"]}");
            Console.WriteLine($"Id:{Configuration["Id"]}");
            Console.WriteLine($"Id:{Configuration["Id"]}");
            Console.WriteLine($"Id:{Configuration["Id"]}");
            Console.WriteLine($"Id:{Configuration["Id"]}");
        }
        /// <summary>
        /// 这个方法被Autofa自动调用
        /// </summary> 负责注册 各种 服务
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TestServiceA>().As<ITestServiceA>(); // 注册 ....
                                                                               //这样 注册 不够，控制器 的创建还要 依赖于其他很多 东西
                                                                               //containerBuilder.RegisterType<SixthController>().As<ControllerBase>();// 注册
            #region  注册  所有控制器的关系+控制器实例化需要的所有组件
            Type[] controllerTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            containerBuilder.RegisterTypes(controllerTypesInAssembly).PropertiesAutowired
                (new CustomPropertySelector());// 注册  完成了让autofac去生成控制器实例
            #endregion
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
            }
            app.UseSession();//222

            //中间件 帮助 读取 静态文件 .js .css
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider= new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot"))
            }
                
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
