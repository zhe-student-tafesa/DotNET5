using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication2.Utility.ViewComponetExtension
{
    [ViewComponent(Name = "CustomList")]
    public class ListViewComponent : ViewComponent
    {
        //返回值 是  IViewComponentResult
        public async Task<IViewComponentResult> InvokeAsync(string searchString) // 异步的 InvokeAsync方法
        {
            //调用
            var list = await GetStudentList(searchString);
            return View(list);
        }

        //做 业务 逻辑
        public Task<List<Student>> GetStudentList(string searchString)
        {
            return Task.Run(() =>
            {
                return new List<Student>()
                {
                new Student(){Id=123, Name="张三"},
                new Student(){Id=222, Name="李四"},
                new Student(){Id=333, Name="王五"},
                new Student(){Id=444, Name="赵六"}
                };
            });
        }
    }




    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}