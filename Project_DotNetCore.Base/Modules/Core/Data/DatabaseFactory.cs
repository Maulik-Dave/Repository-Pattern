using System;

namespace Project_DotNetCore.Base.Modules.Core.Data
{
    public interface IDatabaseFactory : IDisposable
    {
        SqlContext Get();
    }

    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly SqlContext _sqlContext;
        private SqlContext _dataContext;

        public DatabaseFactory(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public SqlContext Get()
        {
            return _dataContext ??= _sqlContext;
        }

        protected override async void DisposeCore()
        {
            if (_dataContext != null)
            {
                await _dataContext.DisposeAsync();
            }

            base.DisposeCore();
        }
    }
}