using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 水刺生产智能管理系统.Models
{
    public class Syschart
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public float speed { get; set; }
    }
}