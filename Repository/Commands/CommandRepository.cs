
using Infrastructure.Entities;

namespace Repository.Commands
{
    public class CommandRepository : ICommandRepository
    {
        private readonly ApplicationContext _context;

        public CommandRepository(ApplicationContext context)
        {
            _context = context;
        }


        #region Async Commands


        public async Task<TEntity> AddSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Add<TEntity>(entity);
            await _context.SaveChangesAsync();
            return entity;
        }



        public async Task<TEntity> UpdateSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Update<TEntity>(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteSaveAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            try
            {
                _context.Remove<TEntity>(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Sync Commands
        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Add<TEntity>(entity);
        }
        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Update<TEntity>(entity);
        }
        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Remove<TEntity>(entity);
        }
        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}


//This is an Generic Repository for Cammands and Change Database Data
//This has Async and Sync Methods for Better Development and Performance With EF Core to SQLServer