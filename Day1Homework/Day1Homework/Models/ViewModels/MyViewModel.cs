﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

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
        public EnumCategory Category { get; set; }
        [DisplayName("金額")]
        public decimal Amount { get; set; }
        [DisplayName("日期")]
        public DateTime Date { get; set; }
        [DisplayName("備註")]
        public string Notes { get; set; }

    }
}