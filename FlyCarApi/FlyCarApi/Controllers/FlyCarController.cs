using Microsoft.AspNetCore.Mvc;
using FlyCarApi.Class;

namespace FlyCarApi.Controllers
{
    public class FlyCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Test")]
        public ActionResult<string> TestConnect()
        {
            return "YesConnect";
        }

        private string GetDataConnect()
        {
            return ConfigHelper.GetConnectionString("SqlServerConnection");
        }

        [HttpPost]//用户注册
        [Route("UserRegist")]
        public ActionResult<string> UserRegist([FromBody] dynamic jsonobject)
        {
            return UserService.AddUser(jsonobject);
        }

        [HttpPost]//用户登录
        [Route("UserLogin")]
        public ActionResult<string> UserLogin([FromBody] dynamic jsonobject)
        {
            return UserService.UserLogin(jsonobject);
        }

        [HttpPost]//用户充值
        [Route("UserRecharge")]
        public ActionResult<string> UserRecharge([FromBody] dynamic jsonobject)
        {
            return UserService.UserRecharge(jsonobject);
        }

        [HttpPost]//Vip开通
        [Route("UserRight")]
        public ActionResult<string> UserRight([FromBody] dynamic jsonobject)
        {
            return UserService.UserRight(jsonobject);
        }

        [HttpPost]//用户余额查询
        [Route("UserAmount")]
        public ActionResult<string> UserAmount([FromBody] dynamic jsonobject)
        {
            return Class.UserService.UserAmount(jsonobject);
        }

        [HttpPost]//所有飞的查询
        [Route("CarGet")]
        public ActionResult<string> CarGet([FromBody] dynamic jsonobject)
        {
            return CarService.CarGet();
        }

        [HttpPost]//飞的预约
        [Route("CarBook")]
        public ActionResult<string> CarBook([FromBody] dynamic jsonobject)
        {
            return CarService.CarBook(jsonobject);
        }

        [HttpPost]//取消预约
        [Route("CancelBook")]
        public ActionResult<string> CancelBook([FromBody] dynamic jsonobject)
        {
            return CarService.CancelBook(jsonobject);
        }

        [HttpPost]//到达确认
        [Route("CarArrive")]
        public ActionResult<string> CarArrive([FromBody] dynamic jsonobject)
        {
            return CarService.CarArrive(jsonobject);
        }

        [HttpPost]//飞的场查询
        [Route("CarParkGet")]
        public ActionResult<string> CarParkGet([FromBody] dynamic jsonobject)
        {
            return CarService.CarParkGet();
        }
    }
}
