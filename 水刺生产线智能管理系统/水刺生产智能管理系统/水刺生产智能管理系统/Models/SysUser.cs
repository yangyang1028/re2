using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 水刺生产智能管理系统.Models
{
    public class SysUser
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int UserId { get; set; }
        public int UserRold { get; set; }
    }
}