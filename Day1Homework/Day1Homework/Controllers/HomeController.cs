using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> items = GetSelectList();

            ViewBag.CategoryItems = items;
            return View();
        }

        [ChildActionOnly]
        public ActionResult GridViewAction()
        {
            var models = GetData();

            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<SelectListItem> GetSelectList()
        {
            var r = new List<SelectListItem>();
            r.Add(new SelectListItem() { Value = "", Text = "請選擇", Selected = true });
            r.Add(new SelectListItem() { Value = "1", Text = "支出" });
            r.Add(new SelectListItem() { Value = "2", Text = "收入" });

            return r;
        }

        private List<MyViewModel> GetData()
        {
            var r = new List<MyViewModel>();
            r.Add(new MyViewModel() { Category = "支出", Date = DateTime.Today, Amount = 300 });
            r.Add(new MyViewModel() { Category = "支出", Date = DateTime.Today.AddDays(1), Amount = 1600 });
            r.Add(new MyViewModel() { Category = "支出", Date = DateTime.Today.AddDays(2), Amount = 800 });

            return r;
        }
    }
}