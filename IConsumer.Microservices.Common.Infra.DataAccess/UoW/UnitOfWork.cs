using IConsumer.Microservices.Common.Domain.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.Common.Infra.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
        }

        public bool Commit()
        {
            if (_context.SaveChanges() > 0)
                return true; //Successful
            return false; //Not successful
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
