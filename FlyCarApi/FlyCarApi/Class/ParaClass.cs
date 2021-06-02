using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCarApi.Class
{
    public class ParaClass
    {
        public class UserInfo//用户表的类（属性尽量和字段相同）
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

        public class User_CarInfo
        {
            public UserInfo UserInfo { get; set; }
            public CarInfo CarInfo { get; set; }
        }
    }
}
