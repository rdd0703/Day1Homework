using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
using Day1Homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _accountBookSvc;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);

        }

        // GET: Admin/Home
        public ActionResult Index(int? page)
        {
            //分頁套件： Install-Package PagedList.Mvc 
            ViewData["pageIndex"] = page.HasValue ? page.Value < 1 ? 1 : page.Value : 1;
            ViewData["pageSize"] = 10;

            return View(_accountBookSvc.ToPagedList((int)ViewData["pageIndex"], (int)ViewData["pageSize"]));
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(Guid id)
        {
            BindSelectList();
            return View(_accountBookSvc.GetSingle(id));
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Category,Amount,Notes,Date")]MyViewModel model)
        {
            if (ModelState.IsValid)
            {

                _accountBookSvc.Edit(model);
                _accountBookSvc.Save();
                return RedirectToAction("Index");

            }
            return View(model);
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
