using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
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

        public IEnumerable<MyViewModel> Lookup()
        {
            var source = _accountBookRep.LookupAll();
            var result = source.Select(d => new MyViewModel()
            {
                Category = (EnumCategory)d.Categoryyy,
                Amount = d.Amounttt,
                Date = d.Dateee,
                Notes = d.Remarkkk
            }).ToList();
            return result;
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