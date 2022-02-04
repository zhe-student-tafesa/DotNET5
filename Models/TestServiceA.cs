using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication2.Models
{
    public  class TestServiceA: ITestServiceA
    {
        public TestServiceA()
        {
            Console.WriteLine($"{ this.GetType().Name}被构造...");
        }

        public void Show()
        {
            Console.WriteLine( "A123");
        }
    }
}
