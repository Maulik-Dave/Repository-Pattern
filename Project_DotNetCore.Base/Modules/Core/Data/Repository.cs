using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Project_DotNetCore.Base.Modules.Core.Data;
using Project_DotNetCore.Base.Modules.Core.Extensions;
using System.Data.Common;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Project_DotNetCore.Base.Modules.Core.Data
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void InsertAsync(T entity);
        //void InsertOrUpdate(T entity);
        //void InsertOrUpdate(IEnumerable<T> entity);
        void Update(T entity);
        void Update(IList<T> entities);
        void Delete(T entity);
        void Delete(IList<T> entities);
        IEnumerable<T> All();
        Task<IEnumerable<T>> AllAsync();
        T Find(int id);
        Task<T> FindAsync(int id);
        IQueryable<T> Table { get; }
        IQueryable<T> AsNoTracking { get; }
        DatabaseFacade GetDatabase();
        DbConnection GetDbConnection();
        string GenerateUniqueSlug(string phrase, int? id = null, string slugFieldName = "Slug");
        Task<string> GenerateUniqueSlugAsync(string phrase, int? id = null, string slugFieldName = "Slug");
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private SqlContext _dataContext;
        private readonly DbSet<T> _dbSet;

        protected IDatabaseFactory DatabaseFactory { get; }
        protected SqlContext DataContext => _dataContext ??= DatabaseFactory.Get();

        public Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = databaseFactory.Get().Set<T>();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            DataContext.Entry(entity).State = EntityState.Added;
        }

        public async void InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            DataContext.Entry(entity).State = EntityState.Added;
        }

        //public void InsertOrUpdate(T entity)
        //{
        //    DataContext.Set<T>().AddOrUpdate(entity);
        //}

        //public void InsertOrUpdate(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //        DataContext.Set<T>().AddOrUpdate(entity);    
        //}

        public void Update(T entity)
        {
            // DataContext.Entry(entity).State = EntityState.Detached;
            _dbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                DataContext.Set<T>().Attach(entity);
                var entry = DataContext.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            DataContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                DataContext.Entry(entity).State = EntityState.Deleted;
            }
        }

        public IEnumerable<T> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> Table => _dbSet;
        public IQueryable<T> AsNoTracking => _dbSet.AsNoTracking();

        public DatabaseFacade GetDatabase()
        {
            return DataContext.Database;
        }

        public DbConnection GetDbConnection()
        {

            return DataContext.Database.GetDbConnection();
        }

        public string GenerateUniqueSlug(string phrase, int? id = null, string slugFieldName = "Slug")
        {
            int? loop = null;
            var slug = phrase.GenerateSlug();

            var where = $"{slugFieldName} = @0";
            if (id != null)
                where += " AND Id <> @1";

            while (AsNoTracking.Where(@where, slug, id).Any())
            {
                loop = loop == null ? 1 : loop + 1;
                slug = phrase.GenerateSlug() + ("-" + loop);
            }

            return slug;
        }

        public async Task<string> GenerateUniqueSlugAsync(string phrase, int? id = null, string slugFieldName = "Slug")
        {
            int? loop = null;
            var slug = phrase.GenerateSlug();

            var where = $"{slugFieldName} = @0";
            if (id != null)
                where += " AND Id <> @1";

            while (await AsNoTracking.Where(@where, slug, id).AnyAsync())
            {
                loop = loop == null ? 1 : loop + 1;
                slug = phrase.GenerateSlug() + ("-" + loop);
            }

            return slug;
        }

    }
}