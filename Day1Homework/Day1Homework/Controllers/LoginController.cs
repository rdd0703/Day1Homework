using Day1Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(LoginViewModel data)
        {
            if (ModelState.IsValid)
            {
                Response.Write("<script>alert('success');</script>");
                return View();
            }
            return View(data);
        }
    }
}