﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class FourthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewComponentTest()
        {
            return View();
        }
    }
}
