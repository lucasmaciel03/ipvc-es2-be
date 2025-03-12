using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Repositories;

namespace FreelanceManagerAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region repositories
        IAppRepository<Client> ClientsRepository { get; }
        #endregion

        int Commit();
        void Rollback();
        Task<int> CommitAsync();
        Task RollbackAsync();
        void Dispose();
        void DisposeAsync();
    }
}
