using AdminApproval.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdminApproval.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(userSignup signup)
        {
            signup.isApproved = 0;
            _context.signup.Add(signup);
            _context.SaveChanges();
            return View();

        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            AdminLogin adminLogin = new AdminLogin();
             string str =  HttpContext.Session.GetString("sessionkey");
            adminLogin.username = str;
            adminLogin.listOfUnApprovedUsers = _context.signup.Where(x => x.isApproved == 0).ToList();
            return View(adminLogin);
        }

        [HttpPost]
        public IActionResult AdminLogin(AdminLogin al)
        {
             userSignup u12 = _context.signup.SingleOrDefault(x => x.id == al.uid);
             u12.isApproved = al.status;
             _context.SaveChanges();
             return RedirectToAction("AdminLogin");
        }

        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }
        [HttpGet]
        public IActionResult details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("sessionkey");
            return RedirectToAction("Admin");
        }
        [HttpGet]
        public IActionResult userLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult userLogin(userSignup us)
        {
            userSignup log =_context.signup.FirstOrDefault(x => x.username == us.username && x.password == us.password);
            if(log == null)
            {
                ViewBag.message = "Signup first";
                return View();
            }
            if(log.isApproved == 1)
            {
                ViewBag.message = "Authorised user";
                return View();
            }
            else
            {
                ViewBag.message = "Non Authorised user";
                return View();
            }

        }

        [HttpPost]

        public IActionResult Admin(Admin a1)
        {
            List<Admin> admin = _context.Admin.Where(x => x.email == a1.email && x.password == a1.password).ToList();
            HttpContext.Session.SetString("sessionkey", a1.email);
            //string sessionValue = HttpContext.Session.GetString("sessionkey");
            if (admin.Count == 0)
            {
                ViewBag.message = "Not a valid admin";
                return View();
            }
            else
            {
                //return RedirectToAction("AdminLogin",a1);
                return View("details");
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
