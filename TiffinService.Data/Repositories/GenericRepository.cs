using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AngularPOC.Entities;

namespace AngularPOC.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region Initialization

        protected readonly AngularPOCDbContext _context;
        protected readonly DbSet<TEntity> Entities;

        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public GenericRepository(AngularPOCDbContext context)
        {
            _context = context;
            Entities = context.Set<TEntity>();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }

            _context.SaveChanges();
            return exception.ToString();
        }

        #endregion

        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).AsEnumerable();
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                Entities.AddRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

    }
}
