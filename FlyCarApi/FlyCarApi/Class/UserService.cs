using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static FlyCarApi.Class.ParaClass;

namespace FlyCarApi.Class
{
    public class UserService
    {
        public static string AddUser(object jsonobject)
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));//json字符串转换object对象
            SQL sql = new SQL("", "user_add");
            DataTable resultTable = sql.ExecSqlProcQuery(new object[] { user.username, user.cellphone, user.password });//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult,sql.ErrorMessage) ==false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, resultTable.Rows[0]["code"].ToString(), resultTable.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string UserLogin(object jsonobject)
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));//json字符串转换object对象
            SQL sql = new SQL("", "user_login");
            DataTable resultTable = sql.ExecSqlProcQuery(new object[] {user.username,user.password});//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if(sqlResult.GetSqlError(sqlResult,sql.ErrorMessage)==false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, resultTable.Rows[0]["code"].ToString(), resultTable.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string UserRecharge(object jsonobject)
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));//json字符串转换object对象
            SQL sql = new SQL("", "user_recharge");
            DataTable resultTable = sql.ExecSqlProcQuery(new object[] { user.username,user.useramount});//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, resultTable.Rows[0]["code"].ToString(), resultTable.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string UserRight(object jsonobject)
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));//json字符串转换object对象
            SQL sql = new SQL("", "user_right");
            DataTable resultTable = sql.ExecSqlProcQuery(new object[] { user.username,user.userright,user.useramount});//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, resultTable.Rows[0]["code"].ToString(), resultTable.Rows[0]["msg"].ToString());
            return JsonConvert.SerializeObject(sqlResult);
        }

        public static string UserAmount(object jsonobject)
        {
            UserInfo user = (UserInfo)JsonConvert.DeserializeObject(jsonobject.ToString(), typeof(UserInfo));//json字符串转换object对象
            SQL sql = new SQL("", "user_get");
            DataTable dataTable = sql.ExecSqlProcQuery(new object[] { user.username });//执行存储结构，传入object数组作为参数
            SQL.SqlResult sqlResult = new SQL.SqlResult();
            if (sqlResult.GetSqlError(sqlResult, sql.ErrorMessage) == false)//系统错误
            {
                return JsonConvert.SerializeObject(sqlResult);//object对象转换json字符串
            }
            sqlResult.GetSqlStatus(sqlResult, "0", "查询成功");
            sqlResult.GetSqlData(sqlResult, dataTable);
            return JsonConvert.SerializeObject(sqlResult);
        }
    }
}
