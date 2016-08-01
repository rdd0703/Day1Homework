using Day1Homework.Models;
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

            ViewBag.MyClassModels = models;
            return View();
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

        private List<MyClassModel> GetData()
        {
            var r = new List<MyClassModel>();
            r.Add(new MyClassModel() { Sn = "1", Category = "支出", Date = "2016-01-01", Amount = "300" });
            r.Add(new MyClassModel() { Sn = "2", Category = "支出", Date = "2016-01-02", Amount = "1,600" });
            r.Add(new MyClassModel() { Sn = "3", Category = "支出", Date = "2016-01-03", Amount = "800" });

            return r;
        }
    }
}