
using Infrastructure.Entities;

namespace Repository.Commands
{
    /// <summary>
    /// a Generic Repository for Commmands (Add , Update , Delete), All methods is Generic 
    /// Used EntityFreamwork Core
    /// </summary>
    public interface ICommandRepository
    {
        /// <summary>
        ///  Async Commands, and They Returns All Saved changes
        /// </summary>
        #region Async Cammands
        public Task<TEntity> AddSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public Task<TEntity> UpdateSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public Task<bool> DeleteSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public Task<bool> SaveAsync();
        #endregion

        /// <summary>
        ///  Sync Commands, and They Returns void and Dosen't Save AnyThing
        /// </summary>
        #region Sync Commands
        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public bool Save();
        #endregion

    }
}