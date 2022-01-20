using DoDo.Application.Contracts.Persistence.Repositories.Commons;
using DoDo.Application.Services.Commons;
using DoDo.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Services.Commons
{
    public partial class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        #region Fields

        private readonly IRepositoryBase<TEntity> _entityRepository;

        #endregion

        #region Ctor

        public ServiceBase(IRepositoryBase<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        #endregion

        #region Methods

        #region Select

        /// <summary>
        /// Gets a entity
        /// </summary>
        /// <param name="entityId">The entity identifier</param>
        /// <returns>Entity</returns>
        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            if (entityId == 0)
                return null;

            return await _entityRepository.GetByIdAsync(entityId);
        }

        public virtual async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<int> entityIds)
        {
            return await _entityRepository.GetByIdsAsync(entityIds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> CountAsync()
        {
            return await _entityRepository.CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual IPagedList<TEntity> GetPagedEntities(Expression<Func<TEntity, bool>> predicate = null, string includeString = null, int pageIndex = 0, int pageSize = int.MaxValue, Sort sort = null)
        {
            var query = _entityRepository.TableNoTracking;

            if (sort != null)
                query = query.Sort(sort);
            else
                query = query.OrderBy(c => c.Id);

            return new PagedList<TEntity>(query, pageIndex, pageSize);
        }


        #endregion

        #region Insert

        /// <summary>
        /// Adds a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //entity.DisplayOrder = CountEntitiesAsync().Result + 1;

            return _entityRepository.AddAsync(entity);

        }

        /// <summary>
        /// Add entities 
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _entityRepository.AddRangeAsync(entities);
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entityRepository.UpdateAsync(entity);

        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _entityRepository.UpdateRangeAsync(entities);
        }



        #endregion

        #region Delete

        /// <summary>
        /// Removes a entity
        /// </summary>
        /// <param name="entitiy">The entitiy</param>
        public virtual async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entityRepository.RemoveAsync(entity);


        }

        /// <summary>
        /// Remove entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _entityRepository.RemoveRangeAsync(entities);
        }

       

        #endregion

        #region Sort

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void DownEntity(TEntity entity )
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var nextEntity = _entityRepository.TableNoTracking.Where(c => c.DisplayOrder > entity.DisplayOrder).OrderBy(c => c.DisplayOrder).FirstOrDefault();
        //    if (nextEntity != null)
        //    {
        //        int entityDisplayOrder = entity.DisplayOrder;
        //        entity.DisplayOrder = nextEntity.DisplayOrder;
        //        nextEntity.DisplayOrder = entityDisplayOrder;

        //        UpdateEntityAsync(entity);
        //        UpdateEntityAsync(nextEntity);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void UpEntity(TEntity entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var nextEntity = _entityRepository.TableNoTracking.Where(c => c.DisplayOrder < entity.DisplayOrder).OrderByDescending(c => c.DisplayOrder).FirstOrDefault();
        //    if (nextEntity != null)
        //    {
        //        int entityDisplayOrder = entity.DisplayOrder;
        //        entity.DisplayOrder = nextEntity.DisplayOrder;
        //        nextEntity.DisplayOrder = entityDisplayOrder;

        //        UpdateEntityAsync(entity);
        //        UpdateEntityAsync(nextEntity);
        //    }
        //}

        #endregion


        #endregion

    }
}
