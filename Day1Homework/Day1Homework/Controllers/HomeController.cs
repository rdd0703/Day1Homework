using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
using Day1Homework.Services;
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
            //Q:如果不再Bind一次，前端會收不到資料而報錯，想請問怎麼做會比較好？
            BindSelectList();

            return View();
        }

        [ChildActionOnly]
        public ActionResult GridViewAction()
        {
            var models = _accountBookSvc.Lookup();

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