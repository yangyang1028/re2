using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 水刺生产智能管理系统.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace 水刺生产智能管理系统.json
{
    public class jsonData
    {
        //将dataset类型的数据转换成json类型

        public string DataTableToJson(DataTable table)
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(table);
            return JsonString;
        }


        /// <summary> 
        /// DataSet转换成Json格式 
        /// </summary> 
        /// <paramname="ds">DataSet</param> 
        ///<returns></returns> 
        //public static string DatasetToJson(DataSet ds, int total = -1)
        //{
        //    StringBuilder json = new StringBuilder();

        //    foreach (DataTable dt in ds.Tables)
        //    {
        //        //{"total":5,"rows":[ 
        //        json.Append("{\"total\":");
        //        if (total == -1)
        //        {
        //            json.Append(dt.Rows.Count);
        //        }
        //        else
        //        {
        //            json.Append(total);
        //        }
        //        json.Append(",\"rows\":[");
        //        json.Append(DataTableToJson(dt));
        //        json.Append("]}");
        //    }
        //    return json.ToString();
        //}




    }
}