using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebQLY.Models;
using WebQLY.Helper;

namespace WebQLY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OracleHelper _connect; // 引入数据库上下文

        // 使用主构造函数
        public HomeController(
            ILogger<HomeController> logger, 
            OracleHelper context)
        {
            _logger = logger;
            _connect = context; // 存储数据库上下文实例
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            var user=_connect.T_SYS_User.SingleOrDefault(m=>m.UserName==username && m.Password==password);
            if (user != null)
            {
                return new JsonResult(new { success = true, message = "登陆成功" });
            }
            return new JsonResult(new { success = false, message = "登陆失败" });
        }

        [HttpPost]
        public JsonResult Register(T_SYS_User register)
        {
            var user=_connect.T_SYS_User.Where(m => m.UserName == register.UserName);
            if (user != null)
            {
                return new JsonResult(new { success = false, message = "用户名已存在" });
            }
            else
            {
                _connect.T_SYS_User.Add(register);
                _connect.SaveChanges();
                return new JsonResult(new { success = true, message = "注册成功" });
            }
        }
    }
}