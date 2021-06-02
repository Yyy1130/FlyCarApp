using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static FlyCarApi.Class.ParaClass;
using static FlyCarApi.Class.UserService;

namespace FlyCarApi.Class
{
    public class CarService
    {
        public static string CarGet()//飞的查询
        {
            SQL sql = new SQL("", "car_get");
            DataTable CarTable = sql.ExecSqlProcQuery(new object[] {});//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            if (CarTable.Rows.Count <= 0)//逻辑错误
            {
                sqlResult.GetSqlStatus(sqlResult, "1", "未有飞的录入");//给出错误信息
                return JsonConvert.SerializeObject(sqlResult);
            }
            sqlResult.GetSqlStatus(sqlResult, "0", "查询成功");
            sqlResult.GetSqlData(sqlResult,CarTable);
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string CarBook(object jsonobject)//飞的预约
        {
            User_CarInfo all = (User_CarInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(User_CarInfo));
            SQL sql = new SQL("", "car_book");
            DataTable result = sql.ExecSqlProcQuery(new object[] {all.CarInfo.carno,all.CarInfo.targetid,all.UserInfo.username,all.UserInfo.useramount});//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, result.Rows[0]["code"].ToString(), result.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string CancelBook(object jsonobject)//取消预约
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));
            SQL sql = new SQL("", "cancel_book");
            DataTable result = sql.ExecSqlProcQuery(new object[] { user.username, user.useramount });//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, result.Rows[0]["code"].ToString(), result.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string CarArrive(object jsonobject)//到达确认
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));
            SQL sql = new SQL("", "car_arrive");
            DataTable result = sql.ExecSqlProcQuery(new object[] { user.username, user.useramount });//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, result.Rows[0]["code"].ToString(), result.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string CarParkGet()//飞的场查询
        {
            SQL sql = new SQL("", "carpark_get");
            DataTable CarParkTable = sql.ExecSqlProcQuery(new object[] { });//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            if (CarParkTable.Rows.Count <= 0)//逻辑错误
            {
                sqlResult.GetSqlStatus(sqlResult, "1", "未有飞的场录入");//给出错误信息
                return JsonConvert.SerializeObject(sqlResult);
            }
            sqlResult.GetSqlStatus(sqlResult, "0", "查询成功");
            sqlResult.GetSqlData(sqlResult, CarParkTable);
            return JsonConvert.SerializeObject(sqlResult);
        }
    }
}
