using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using 水刺生产智能管理系统.json;

namespace 水刺生产智能管理系统.Models
{
    public class Method
    {
        /// <summary>
        /// 判断用户名和密码是否正确
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public SysUser UserLogin(SysUser objUser)
        {
            //sql查询字符串
            string sql = string.Format("select * from userTable where UserName='{0}' and UserPwd='{1}'", objUser.UserName, objUser.UserPwd);
            //将sql语句传递到GetReader()方法中，在数据库中查询数据
            SqlDataReader ds = SQLHelper.GetReader(sql);
            ///判断ds中所有的数据都不为空，不为空时将用户名和权限复制给objUser对象并返回，为空时将null复制给objUser对象并返回
            try
            {
                if (ds.Read())
                {
                    objUser.UserName = ds["UserName"].ToString();
                    objUser.UserRold = Convert.ToInt32(ds["Role"]);
                    return objUser;
                }
                else
                {
                    return objUser=null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }



        /// <summary>
        /// 查询数据数据库中的数据
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns>List<Syschart></returns>
        public List<Syschart> chart1()
        {
            //查询数据
            string sql = string.Format("select * from echarts");
            //返回数据
            DataSet ds = SQLHelper.GetDataSet(sql);
            //判断是否查询到数据
            if (ds.Tables[0].Rows.Count != 0 && ds != null && ds.Tables.Count != 0)
            {
                //List<Syschart> chart = new List<Syschart>//定义集合
                //{
                //    //向集合内添加数据
                //    new Syschart{id=1,time=Convert.ToDateTime("2019-08-07 09:00:00"),speed=(float)5.21},
                //    new Syschart{id=2,time=Convert.ToDateTime("2019-08-07 09:01:00"),speed=(float)1.234}
                //};

                //创建集合
                List<Syschart> chart = new List<Syschart>();
                //向集合内循环赋值
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //向集合内添加新的Syschart类型的数据
                    chart.Add(new Syschart { id =i+1, time = Convert.ToDateTime(ds.Tables[0].Rows[i]["time"]), speed =float.Parse( ds.Tables[0].Rows[i]["speed"].ToString()) });
                }
               
                //返回集合
                return chart;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 查询数据数据库中的数据
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns>List<Syschart></returns>
        public List<Syschart> chart2()
        {
            string sql = string.Format("select * from echarts");
            DataTable dt = SQLHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count!=0)
            {
                List<Syschart> chart = new List<Syschart>();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    chart.Add(new Syschart { id = i + 1, time = Convert.ToDateTime(dt.Rows[i]["time"]), speed = float.Parse(dt.Rows[i]["speed"].ToString()) });
                }
                return chart;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询数据数据库中的数据
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns>DataTable</returns>
        public DataTable chart3()
        {
            string sql=string.Format("select * from echarts");
            DataTable dt = SQLHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count != 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public string chart4()
        {
            string sql = string.Format("select * from echarts");
            DataTable dt = SQLHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count != 0)
            {
                var Jsondata=new jsonData().DataTableToJson(dt);  
                return Jsondata;
            }
            else
            {
                return null;
            }
        }

        
    }
}