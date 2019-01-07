using System;

namespace AngularPOC.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AngularPOCDbContext _context;

        public UnitOfWork(AngularPOCDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
