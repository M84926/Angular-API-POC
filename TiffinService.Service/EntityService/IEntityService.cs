using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularPOC.Service.EntityService
{
    public interface IEntityService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

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
