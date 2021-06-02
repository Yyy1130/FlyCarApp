using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlyCarApp.Class
{
    public class ParaClass
    {
        public ParaClass(UserInfo userInfo,CarInfo carInfo)
        {
            
        }
        public static class RecentUser
        {
            public static string username { get; set; }
            public static string cellphone { get; set; }
            public static int userright { get; set; }
            public static float useramount { get; set; }
        }

        public static void rebuild()
        {
            RecentUser.username = null;
            RecentUser.cellphone = null;
            RecentUser.userright = -1;
            RecentUser.useramount = -1;
        }
        public static class RecentCar
        {
            public static string carno { get; set; }
            public static string status { get; set; }
            public static int xpoint { get; set; }
            public static int ypoint { get; set; }
            public static int cpid { get; set; }
        }
        public class UserInfo
        {
            public string username { get; set; }
            public int id { get; set; }
            public string password { get; set; }
            public string cellphone { get; set; }
            public int userright { get; set; }
            public float useramount { get; set; }
        }

        public class CarInfo
        {
            public string carno { get; set; }
            public string status { get; set; }
            public int cpid { get; set; }
            public int targetid { get; set; }
        }
        public class ResultInfo
        {
            public string code { get; set; }//执行代码，“0”为成功，“1”为失败，有扩展性
            public string msg { get; set; }//结果信息
            public DataTable data { get; set; }//具体数据
        }

        public class User_CarInfo
        {
            public UserInfo UserInfo { get; set; }
            public CarInfo CarInfo { get; set; }
        }
    }
}
