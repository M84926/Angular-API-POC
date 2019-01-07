using System;

namespace AngularPOC.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
