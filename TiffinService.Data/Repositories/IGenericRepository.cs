using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AngularPOC.Entities;

namespace AngularPOC.Data.Repositories
{
    public partial interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

        TEntity GetById(object id);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> list);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> list);
    }
}
