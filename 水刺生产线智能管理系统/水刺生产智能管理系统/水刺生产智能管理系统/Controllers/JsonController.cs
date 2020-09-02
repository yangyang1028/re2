using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using 水刺生产智能管理系统.Models;

namespace 水刺生产智能管理系统.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public JsonResult BookInfo()
        {
            List<Syschart> chart = new List<Syschart>();//定义集合
            chart = new Method().chart2();//将模型层返回的数据赋值给集合
            if (chart != null)//判断集合内是否有值 
            {
               return Json(chart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.Write("<script>alert('程序错误')</script>");
                return null;
            }
            
            //ResultJsonInfo resultInfo = new ResultJsonInfo();
            //resultInfo.Result = true;
            //resultInfo.Msg = "好啊";
            //return Json(resultInfo, JsonRequestBehavior.AllowGet);
        }
        
    }
}