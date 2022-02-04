using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Utility.RazorGrammar
{
    [HtmlTargetElement("Hello")]
    public   class CustomTagHelperTest : TagHelper// 继承 TagHelper这个类
    {
         public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";//生成 一个 div
            output.Attributes.Add("dir","123");// 添加 一个 属性
            output.Attributes.Add("name", "Frank");// 添加 一个 属性
            output.PreContent.SetContent("红红火火"); // 添加  内容

            base.Process(context, output);
        }
    }
}