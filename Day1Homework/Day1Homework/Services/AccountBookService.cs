using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.Services
{
    public class AccountBookService : Repository<AccountBook>
    {
        //Q:請問實務上每一個table都要手動寫一個Service嗎？
        private readonly IRepository<AccountBook> _accountBookRep;

        public AccountBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _accountBookRep = new Repository<AccountBook>(unitOfWork);
        }

        public MyViewModel GetSingle(Guid id)
        {
            var accountBook = _accountBookRep.GetSingle(d => d.Id == id);
            var model = new MyViewModel()
            {
                id = accountBook.Id,
                Category = (EnumCategory)accountBook.Categoryyy,
                Amount = accountBook.Amounttt,
                Date = accountBook.Dateee,
                Notes = accountBook.Remarkkk
            };

            return model;
        }

        public IEnumerable<MyViewModel> LookupAll()
        {
            var source = _accountBookRep.LookupAll();
            var result = source.Select(d => new MyViewModel()
            {
                id = d.Id,
                Category = (EnumCategory)d.Categoryyy,
                Amount = d.Amounttt,
                Date = d.Dateee,
                Notes = d.Remarkkk
            }).OrderByDescending(d => d.Date).ToList();
            return result;
        }

        public IEnumerable<MyViewModel> ToPagedList(int pageIndex, int pageSize)
        {
            return LookupAll().ToPagedList(pageIndex, pageSize);
        }

        public void Edit(MyViewModel pageData)
        {
            var oldData = _accountBookRep.GetSingle(d => d.Id == pageData.id);
            if (oldData != null)
            {
                oldData.Categoryyy = (int)pageData.Category;
                oldData.Amounttt = pageData.Amount;
                oldData.Dateee = pageData.Date;
                oldData.Remarkkk = pageData.Notes;
            }
        }

        public void Add(MyViewModel vm)
        {
            _accountBookRep.Create(new AccountBook
            {
                Id = Guid.NewGuid(),
                Categoryyy = (int)vm.Category,
                Amounttt = Convert.ToInt32(vm.Amount),
                Dateee = vm.Date,
                Remarkkk = vm.Notes
            });
        }

        public void Save()
        {
            _accountBookRep.Commit();
        }
    }
}