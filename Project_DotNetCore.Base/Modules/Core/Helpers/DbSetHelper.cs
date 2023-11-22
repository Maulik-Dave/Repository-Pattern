using System;
using Microsoft.EntityFrameworkCore;

namespace Project_DotNetCore.Base.Modules.Core.Helpers
{
    public static class DbSetHelper
    {
        public static TEntity AddOrUpdate<TEntity>(this DbSet<TEntity> dbSet, DbContext context, Func<TEntity, object> identifier, TEntity entity) where TEntity : class
        {
            var result = dbSet.Find(identifier.Invoke(entity));
            
            if (result != null)
            {
                context.Entry(result).CurrentValues.SetValues(entity);
                dbSet.Update(result);
                return result;
            }

            dbSet.Add(entity);
            return entity;
        }

    }
}