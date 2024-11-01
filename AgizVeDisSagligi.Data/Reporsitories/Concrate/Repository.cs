using AgizVeDisSagligi.Data.Context;
using AgizVeDisSagligi.Data.Reporsitories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AgizVeDisSagligi.Entity.Entites;

namespace AgizVeDisSagligi.Data.Reporsitories.Concrate
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public readonly AppDbContext dbContext;
        public Repository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return query.SingleAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return Table.AnyAsync(predicate);
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }

        public async Task<Suggestion> GetRandomSuggestionAsync()
        {
            int suggestionCount = await dbContext.Suggestions.CountAsync();
            var random = new Random();
            int randomId = random.Next(1, suggestionCount + 1);

            return await dbContext.Suggestions.FindAsync(randomId);
        }
    }
}
