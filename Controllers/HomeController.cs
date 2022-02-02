using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _Configuration;

        public HomeController(ILogger<HomeController> logger, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _logger = logger;
            _logger.LogWarning("HomeController被构造");
            _Configuration = configuration;//在构造函数依赖注入， 在此初始化

        }

        public IActionResult Index()
        {
            _logger.LogInformation("这是HomeController的index 方法");
            base.ViewBag.User1 = "张三";
            base.ViewData["User2"] = "李四";
            base.TempData["User3"] = "王五";
            object user4 = "赵六";
            if (HttpContext.Session.GetString("User5") == null)
            {
                HttpContext.Session.SetString("User5","田七");
            }
            ViewBag.configInfo = _Configuration["Id"];

            return View(user4);
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
