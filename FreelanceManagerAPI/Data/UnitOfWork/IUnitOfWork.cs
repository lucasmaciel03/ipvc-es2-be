using FreelanceManagerAPI.Data.Entities;

namespace FreelanceManagerAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region repositories

        #endregion

        int Commit();
        void Rollback();
        Task<int> CommitAsync();
        Task RollbackAsync();
        void Dispose();
        void DisposeAsync();
    }
}
