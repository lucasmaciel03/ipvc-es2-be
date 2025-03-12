using FreelanceManagerAPI.Data.Context;
using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Repositories;
using FreelanceManagerAPI.Data.UnitOfWork;

namespace FreelanceManagerAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _databaseContext;

        #region repositories
        private IAppRepository<Client> _clientsRepository;
        #endregion

        public UnitOfWork(AppDBContext dbContext)
        {
            _databaseContext = dbContext;
        }

        #region repositories
        public IAppRepository<Client> ClientsRepository
        {
            get { return _clientsRepository ??= new AppRepository<Client>(_databaseContext); }
        }
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
