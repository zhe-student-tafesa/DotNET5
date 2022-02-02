using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DbConnectionOptions
    {
        //定义 一个实体，结构 与 json中 要读取的结构一样 WriteConnection， ReadConnectionList 是list数组
        public string WriteConnection { get; set; }

        public  List<string> ReadConnectionList { get; set; }
    }
}
