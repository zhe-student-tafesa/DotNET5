using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;//IsoDateTimeConverter 
 

namespace WebApplication2.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _Configuration;
        private readonly DbConnectionOptions _optionsCurrent;//11 定义 DbConnectionOptions 类型的变量（用来读取配置文件）
        //IOptions引入，是一个 泛型的接口
        public FirstController(ILogger<FirstController> logger, Microsoft.Extensions.Configuration.IConfiguration configuration, IOptions<DbConnectionOptions> options)
        {
            _optionsCurrent= options.Value;  //22 在构造函数里 初始化
            _logger = logger;
            _logger.LogWarning("FirstController被构造");
            _Configuration = configuration;//在构造函数依赖注入， 在此初始化

        }

        public IActionResult Index()
        {
            _logger.LogInformation("这是FirstController的index 方法");
            base.ViewBag.User1 = "张三";
            base.ViewData["User2"] = "李四";
            base.TempData["User3"] = "王五";
            object user4 = "赵六";
            if (HttpContext.Session.GetString("User5") == null)
            {
                HttpContext.Session.SetString("User5","田七");
            }
            ViewBag.configInfo = _Configuration["Id"];
            object strResult = Newtonsoft.Json.JsonConvert.SerializeObject(_optionsCurrent);// 使用 Newtonsoft.Json 序列化

            return View(strResult);
        }
        public void Index1(int i)
        {
        }
        public void Index2(string i)
        {
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
