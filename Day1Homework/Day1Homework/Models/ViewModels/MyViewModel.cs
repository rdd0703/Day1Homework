using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Models.ViewModels
{
    public enum EnumCategory
    {
        支出,
        收入
    }
    public class MyViewModel
    {
        [DisplayName("類別")]
        [Required]
        public EnumCategory Category { get; set; }

        [DisplayName("金額")]
        [Range(0,int.MaxValue,ErrorMessage ="{0} 必須大於 {1}")]
        public int Amount { get; set; }

        [DisplayName("日期")]
        [Remote("DateValidation", "Valid", ErrorMessage = "{0} 不得大於今天")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 不可超過 {1} 個字元")]
        [DisplayName("備註")]
        public string Notes { get; set; }

    }
}