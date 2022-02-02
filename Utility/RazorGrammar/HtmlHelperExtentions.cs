using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Utility.RazorGrammar
{
    public static class HtmlHelperExtentions
    {
        public static IHtmlContent Br(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper )
        {
            //IHtmlContent 是一个接口，所以必须返回 接口的实现类
            return new HtmlString($"</br>");
        }
        public static IHtmlContent Img(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper helper,string src)
        {
            //IHtmlContent 是一个接口，所以必须返回 接口的实现类
            return new HtmlString($"<img src='{src}' />");
        }

    }
}