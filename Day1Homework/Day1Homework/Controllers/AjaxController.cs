using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
using Day1Homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class AjaxController : Controller
    {
        private readonly AccountBookService _accountBookSvc;

        public AjaxController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);

        }

        // GET: Ajax
        public ActionResult Index()
        {
            BindSelectList();
            return View();
        }

        [ChildActionOnly]
        public ActionResult GridViewAction()
        {
            var models = _accountBookSvc.LookupAll();

            return View(models);
        }

        [HttpPost]
        public ActionResult GridViewAction(MyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accountBook = new AccountBook
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = (int)model.Category,
                    Amounttt = Convert.ToInt32(model.Amount),
                    Dateee = model.Date,
                    Remarkkk = model.Notes
                };
                _accountBookSvc.Create(accountBook);
                _accountBookSvc.Save();

            }
            BindSelectList();

            var models = _accountBookSvc.LookupAll();

            return View(models);
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