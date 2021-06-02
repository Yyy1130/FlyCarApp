using System;
using System.Data;
using System.Data.SqlClient;

public class SQL
{
    private string Connectstring { get; set; }//连接字符串
    private int ExecTimeOut { get; set; }//超时时间
    public string ErrorMessage { get; set; }//错误信息
    private string ProcName { get; set; }//存储过程名称
    private string SqlCmd { get; set; }//sql语句

    public SQL(string _SqlCmd,string _ProcName)//构造函数赋初值，避免遗漏属性的赋值
    {
        ExecTimeOut =15;
        ErrorMessage = "";
        Connectstring = ConfigHelper.GetConnectionString("SqlServerConnection");
        SqlCmd = _SqlCmd;
        ProcName = _ProcName;
    }
    
    public DataTable ExecSqlQuery()//返回数据集（DataTable）
    {
        DataTable result = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(Connectstring))
        {
            using (SqlCommand sqlCommand = new SqlCommand(SqlCmd, sqlConnection))
            {
                try
                {
                    SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                    sqlData.Fill(result);
                }
                catch (Exception ev)
                {
                    ErrorMessage = ev.Message;
                }
            }
        }
        return result;
    }
    public int ExecSqlNonQuery()//返回受影响的行数
    {
        int row = -1;
        using (SqlConnection sqlConnection = new SqlConnection(Connectstring))
        {
            using (SqlCommand sqlCommand = new SqlCommand(SqlCmd, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    row =sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ev)
                {
                    ErrorMessage = ev.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        return row;
    }
    public object ExecSqlScalarQuery()//返回一个唯一的字段
    {
        object result = new object();
        using (SqlConnection sqlConnection = new SqlConnection(Connectstring))
        {
            using (SqlCommand sqlCommand = new SqlCommand(SqlCmd, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    result = sqlCommand.ExecuteScalar();
                }
                catch (Exception ev)
                {
                    ErrorMessage = ev.Message;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        return result;
    }

     private string GetParas(object[] paras)//拼接存储结构的字符串，样例为：exec 存储过程名称 'string参数',int参数
    {
        string procstring = "exec " + ProcName + " ";
        string parastring = "";
        for (int i = 0; i <= paras.Length - 1; i++)
        {
            if (paras[i].GetType().ToString().ToUpper().IndexOf ("INT")==-1)//判断是否为int
                parastring += "'" + paras[i] + "',";
            else
                parastring +=  paras[i] + ",";
        }
        if (parastring != "")
            parastring = parastring.Substring(0, parastring.Length - 1);//删除最后一个逗号
        procstring += parastring;
        return procstring;
    }
    public DataTable ExecSqlProcQuery(object[] paras)//存储过程的返回数据集，下同
    {
        DataTable result = new DataTable();
        SQL sql = new SQL(GetParas(paras),ProcName);
        result = sql.ExecSqlQuery();
        this.ErrorMessage = sql.ErrorMessage;
        return result;
    }
    public int ExecSqlProcNonQuery(object[] paras)
    {
        int row = -1;
        SQL sql = new SQL(GetParas(paras), ProcName);
        row = sql.ExecSqlNonQuery();
        this.ErrorMessage = sql.ErrorMessage;
        return row;
    }
    public object ExecSqlProcScalarQuery(object[] paras)
    {
        object result = new object();
        SQL sql = new SQL(GetParas(paras), ProcName);
        result = sql.ExecSqlScalarQuery();
        this.ErrorMessage = sql.ErrorMessage;
        return result;
    }
    public class SqlResult//错误返回类
    {
        public string code { get; set; }//执行代码，“0”为成功，“1”为失败，有扩展性
        public string msg { get; set; }//结果信息
        public DataTable data { get; set; }//具体数据

        public bool GetSqlError(SqlResult SqlResult, string errormessage)//系统错误
        {
            if (errormessage != "")
            {
                SqlResult.code = "1";
                SqlResult.msg = errormessage;
                return false;
            }
            else
            {
                SqlResult.code = "0";
                return true;
            }
        }
        public void GetSqlStatus(SqlResult SqlResult, string code, string message)
        {
            SqlResult.code = code;
            SqlResult.msg = message;
        }
        public void GetSqlData(SqlResult SqlResult, DataTable result)
        {
            SqlResult.data = result;
        }
    }
}

