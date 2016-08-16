using Day1Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Helpers
{
    public static class AccountHelper
    {
        public static MvcHtmlString CategoryWithColor(this MyViewModel vm)
        {
            string html = string.Empty;
            switch (vm.Category)
            {
                case EnumCategory.支出:
                    html = $"<span class='text-danger'>{vm.Category}</span>";
                    break;
                case EnumCategory.收入:
                    html= $"<span class='text-primary'>{vm.Category}</span>";
                    break;  
                default:
                    break;
            }

            return MvcHtmlString.Create(html);
        }
    }
}