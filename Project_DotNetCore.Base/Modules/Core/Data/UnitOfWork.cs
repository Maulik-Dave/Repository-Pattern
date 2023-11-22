using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Project_DotNetCore.Base.Modules.Core.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void BeginTransaction();
        Task BeginTransactionAsync();
        void Rollback();
        Task RollbackAsync();
        void CompleteTransaction();
        Task CompleteTransactionAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private SqlContext _dataContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected SqlContext DataContext => _dataContext ??= _databaseFactory.Get();

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = DataContext.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await DataContext.Database.BeginTransactionAsync();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public void CompleteTransaction()
        {
            _transaction?.Commit();
        }

        public async Task CompleteTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction?.CommitAsync();
            }
        }
    }
}