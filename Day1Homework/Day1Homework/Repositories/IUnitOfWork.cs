using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Day1Homework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// context
        /// </summary>
        DbContext Context { get; set; }
        /// <summary>
        /// save change
        /// </summary>
        void Save();
    }
}