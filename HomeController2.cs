using FinalProjectForms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectForms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var res = 
             System.IO.File.ReadAllText("wwwroot\\loginpage.html");
            return Content(res, "text/html");
        }
        public ActionResult LoginMethod()
        {
            // real-login to flight center system

            if (Request.Form["username"] != 
                Request.Form["password"])   {
                var res = System.IO.File.
                    ReadAllText("wwwroot\\loginpage.html");
                res = res + 
                  "<br><p style=\"color:red\">wrong password</p>";
                return Content(res, "text/html");
            }
            else
            {
                string path = "wwwroot\\" +
                    (Request.Form["username"].ToString().ToUpper() 
                    == "admin".ToUpper() ? "admin" :
                    Request.Form["username"].ToString().ToUpper() 
                    == "airline".ToUpper() ? "airline" :
                    Request.Form["username"].ToString().ToUpper() 
                    == "customer".ToUpper() ? "customer" :
                    "anonyn") + ".html";
                var html = System.IO.File.ReadAllText(path);
                html = html + "<br><br><button onclick=\"window.history.back();\">back to login</button>";
                return Content(html, "text/html");
            }
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
    }
}
