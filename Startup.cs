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
