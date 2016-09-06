using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
using Day1Homework.Services;
using PagedList;
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
        private readonly AccountBookService _accountBookSvc;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);

        }

        public ActionResult Index()
        {
            BindSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _accountBookSvc.Add(model);
                _accountBookSvc.Save();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult GridViewAction(int? year, int? month, int? page)
        {
            //分頁套件： Install-Package PagedList.Mvc 
            ViewData["pageIndex"] = page.HasValue ? page.Value < 1 ? 1 : page.Value : 1;
            ViewData["pageSize"] = 10;

            var pageData = _accountBookSvc.LookupAll();

            if (year.HasValue && month.HasValue)
                pageData = pageData.Where(d => d.Date.Year == year && d.Date.Month == month);
            
            pageData = pageData.ToPagedList((int)ViewData["pageIndex"], (int)ViewData["pageSize"]);

            return View(pageData);
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

        private void BindSelectList()
        {
            List<SelectListItem> items = GetSelectList();
            ViewBag.CategoryItems = items;
        }

        private List<SelectListItem> GetSelectList()
        {
            var r = new List<SelectListItem>();
            r.Add(new SelectListItem() { Value = "", Text = "請選擇", Selected = true });
            r.Add(new SelectListItem() { Value = "0", Text = "支出" });
            r.Add(new SelectListItem() { Value = "1", Text = "收入" });

            return r;
        }

    }
}