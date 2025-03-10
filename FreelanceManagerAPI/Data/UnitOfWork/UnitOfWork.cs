using FreelanceManagerAPI.Data.Context;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.UnitOfWork;

namespace CleverTours_API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _databaseContext;

        #region repositories

        #endregion

        public UnitOfWork(AppDBContext dbContext)
        {
            _databaseContext = dbContext;
        }

        #region repositories

        #endregion

        public int Commit() => _databaseContext.SaveChanges();
        public void Rollback() => _databaseContext.Dispose();
        public async Task<int> CommitAsync() => await _databaseContext.SaveChangesAsync();
        public async Task RollbackAsync() => await _databaseContext.DisposeAsync();

        public void Dispose()
        {
            _databaseContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void DisposeAsync()
        {
            _databaseContext?.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
