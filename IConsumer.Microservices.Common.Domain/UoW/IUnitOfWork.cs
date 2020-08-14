using System;
using System.Collections.Generic;
using System.Text;

namespace IConsumer.Microservices.Common.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        public void BeginTransaction();
        public bool Commit();
    }
}
