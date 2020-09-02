using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 水刺生产智能管理系统.Models
{
    public class Class1
    {
        public List<Syschart> chart1()
        {
            var chart = new List<Syschart>()
            {
                new Syschart{ id=1,time=Convert.ToDateTime("2019-08-07 09:00:00"),speed=(float)5.21},
                new Syschart{id=2,time=Convert.ToDateTime("2019-08-07 09:01:00"),speed=(float)1.234}
            };
            return chart;
        }
    }
}