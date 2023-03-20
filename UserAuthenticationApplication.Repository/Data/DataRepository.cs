using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.DbContexts;

namespace UserAuthenticationApplication.Repository.DataRepository
{
    public class DataRepository : IDataRepository
    {
        private readonly UserDbContext _userDbContext;

        public DataRepository( UserDbContext userDbContext) 
        {
          _userDbContext = userDbContext;
        }


        public async Task AddAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            await dbSet.AddAsync(entity);
            await _userDbContext.SaveChangesAsync();

        }

        public Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }
        public Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            return await dbSet.FirstAsync(predicate);
        }

        public Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            return dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            var values = await dbSet.ToListAsync<T>();
            return values;
        }

        public IDbContextTransaction GetTransaction()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            dbSet.Remove(entity);
            await _userDbContext.SaveChangesAsync();
        }

        public Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tresult> Select<T, Tresult>(Expression<Func<T, Tresult>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public void TransactionBegin()
        {
            throw new NotImplementedException();
        }

        public void TransactionCommit()
        {
            throw new NotImplementedException();
        }

        public void TransactionRollback()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();
            dbSet.Update(entity);
            await _userDbContext.SaveChangesAsync();
        }

        public Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbSet = CreateDbSetAsync<T>();

            return dbSet.Where(predicate);
        }
        private DbSet<T> CreateDbSetAsync<T>()
        where T : class
        {
            return _userDbContext.Set<T>();
        }
    }
}
