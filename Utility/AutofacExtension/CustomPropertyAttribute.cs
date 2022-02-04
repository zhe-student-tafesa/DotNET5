using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication2.Utility.AutofacExtension
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CustomPropertyAttribute:Attribute// 特性
    {
    }
}