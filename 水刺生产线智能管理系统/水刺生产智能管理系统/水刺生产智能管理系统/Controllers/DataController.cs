using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 水刺生产智能管理系统.Models;

namespace 水刺生产智能管理系统.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        
        public ActionResult Login()
        {
            //判断session中是否有数据，如果有赋值为空
            if(Session["UserName"] != null && Session["Role"] != null)
            {
                //Session.Abandon();//清除session中的所有数据
                Session["UserName"] = null;
                Session["Role"] = null;
                return View("Login");
            }
            else
            {
                return View("Login");//返回登陆页面
            }
            
        }

        public ActionResult UserLogin()//判断用户是否正确登陆
        {
            //定义新的对象，并取得视图页面中表单传过来的数据
            SysUser objUser = new SysUser()
            {
                UserName = Request.Params["name"],
                UserPwd = Request.Params["pwd"]
            };
            
            try
            {
                //判断输入的用户名和密码是否与数据库中的是否匹配
                if (objUser.UserName!=null && objUser.UserPwd!=null)
                {
                    objUser = new Method().UserLogin(objUser);
                    if (objUser != null)
                    {
                        Session["UserName"] = objUser.UserName;
                        Session["Role"] = objUser.UserRold;
                        objUser.UserName = null;objUser.UserPwd = null;
                        return RedirectToAction("Index", "Main");//返回Main控制器中的Index方法
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名或密码错误')</script>");
                        return this.Login();
                    }
                }
                else
                {
                    return this.Login();
                }
                
            }
            catch ( Exception ex)
            {
                return null;
            }
            
        }
    }
}