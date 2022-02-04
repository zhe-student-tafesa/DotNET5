using Microsoft.AspNetCore.Mvc;

 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FifthController : Controller
    {
        private readonly ITestServiceA _ITestServiceA = null;
        public FifthController(ITestServiceA iTestServiceA)// 构造函数
        {
            _ITestServiceA = iTestServiceA;
        }
        public IActionResult Index()
        {
            _ITestServiceA.Show();
            return View();
        }
        public IActionResult ViewComponentTest()
        {
            return View();
        }
    }
}
