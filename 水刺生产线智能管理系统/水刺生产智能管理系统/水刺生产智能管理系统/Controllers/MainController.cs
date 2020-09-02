using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using 水刺生产智能管理系统.Models;

namespace 水刺生产智能管理系统.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        //public List<Syschart> chart1()
        //{
        //    var chart = new List<Syschart>()
        //    {
        //        new Syschart{ id=1,time=Convert.ToDateTime("2019-08-07 09:00:00"),speed=(float)5.21},
        //        new Syschart{id=2,time=Convert.ToDateTime("2019-08-07 09:01:00"),speed=(float)1.234}
        //    };
        //    return chart;
        //}
        public ActionResult Index()
        {
           return this.judge("Index");
        }
        public ActionResult chart()
        {
            //检测session中是否有数据
            //return this.judge("chart");
            //return View();
            //var data = new Method().chart4();
            //if (data != null)
            //{
            //    return View(data);
            //}
            //else
            //{
            //    return View();
            //}


            List<Syschart> chart = new List<Syschart>();//定义集合
            chart = new Method().chart2();//将模型层返回的数据赋值给集合
            if (chart != null)//判断集合内是否有值 
            {

                var chartModel = new Tuple<List<Syschart>>(chart);//将集合添加到tuple中
                return View(chartModel);//返回给视图层
            }
            else
            {
                Response.Write("<script>alert('程序错误')</script>");
                return View();
            }

            //三种控制器向视图层传值的方法
            //1、新建viewmodel向视图传递集合数据
            //var chart = new Models.Class2()
            //{
            //    chart = chart1(),

            //};
            //return View(chart);

            //2、使用dynamic传递数据
            //dynamic chart = new ExpandoObject();
            //chart.chart1 = chart1();
            //return View(chart);



            //3、使用Tuole传递数据
            //var chart1 = this.chart1();
            //var chartModel = new Tuple<List<Syschart>>(chart1);
            //return View(chartModel);
        }
        



        //判断session中是否有数据
        public ActionResult judge( string address)
        {
            if (Session["UserName"] != null && Session["Role"] != null)
            {
                return View(address);
            }
            else
            {
                //返回Data控制器的Login方法
                return RedirectToAction("Login", "Data");
            }
        }
        public ActionResult data()
        {

            //var data ={ 51, 52, 56, 1, 12, 40, 10};
            return View("chart");
        }
        
    }
}