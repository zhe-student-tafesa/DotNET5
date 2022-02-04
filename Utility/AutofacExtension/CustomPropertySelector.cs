using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication2.Utility.AutofacExtension
{
    public class CustomPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            //需要 一个 判断 的维度
            return propertyInfo.CustomAttributes.Any(it=> it.AttributeType==typeof
            (CustomPropertyAttribute));// 看 是否 有 CustomPropertyAttribute 属性 标记

        }
    }
}
