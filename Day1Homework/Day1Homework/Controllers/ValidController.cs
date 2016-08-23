using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        public ActionResult Index(string account)
        {
            string[] keys = new string[] { "skilltree", "demo", "twMVC" };

            bool isValidate = !keys.Any(d => account.Contains(d));

            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DateValidation(DateTime date)
        {
            bool isValidate = date.Date <= DateTime.Today;

            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}