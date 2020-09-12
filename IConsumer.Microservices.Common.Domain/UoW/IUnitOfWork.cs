using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.Common.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        public void BeginTransaction();
        public bool Commit();
        public Task<int> SaveChangesAsync();
    }
}
