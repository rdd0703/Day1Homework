using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="帳號")]
        [Remote("Index", "Valid", ErrorMessage = "名稱不可包含以下字串：[skilltree,demo,twMVC]")]
        public string Account { get; set; }

        [Display(Name ="密碼")]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }

    }
}