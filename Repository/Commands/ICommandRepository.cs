
using Infrastructure.Entities;

namespace Repository.Commands
{
    public interface ICommandRepository
    {
        #region Async Cammands
        public Task<TEntity> AddSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity; 
        public Task<TEntity> UpdateSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public Task<bool> DeleteSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public Task<bool> SaveAsync();
        #endregion

        #region Sync Commands
        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public bool Save();
        #endregion

    }
}