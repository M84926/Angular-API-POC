using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AngularPOC.Data.Repositories;
using AngularPOC.Entities;

namespace AngularPOC.Service.EntityService
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : BaseEntity
    {
        #region Initialization

        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EntityService(IGenericRepository<TEntity> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public TEntity GetById(object id)
        {
            return _genericRepository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _genericRepository.Table.ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _genericRepository.FindBy(predicate);
        }

        public void Insert(TEntity entity)
        {
            _genericRepository.Insert(entity);
        }

        public void Insert(IEnumerable<TEntity> list)
        {
            _genericRepository.Insert(list);
        }

        public void Update(TEntity entity)
        {
            _genericRepository.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _genericRepository.Update(entities);
        }

        public void Delete(TEntity entity)
        {
            _genericRepository.Delete(entity);
        }

        public void Delete(IEnumerable<TEntity> list)
        {
            _genericRepository.Delete(list);
        }

        #endregion

    }
}
