using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BookingApp.Infrastructure.Core.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        protected BookingAppDbContext Context { get; set; }

        protected RepositoryBase(BookingAppDbContext context)
        {
            this.Context = context;
        }

        public IQueryable<T> FindAll()
        {
            return this.Context.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.Context.Set<T>()
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
            => await this.Context
            .Set<T>()
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<T>> FindAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = this.Context.Set<T>().AsNoTracking();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
            => await this.Context
            .Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(n => n.Id == id)
            .ConfigureAwait(false);

        public async Task AddAsync(T entity)
        {
            await this.Context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        public async ValueTask<EntityEntry<T>> AddEntityAsync(T entity)
        {
            var restult = await this.Context.Set<T>().AddAsync(entity);
            await this.Context.SaveChangesAsync().ConfigureAwait(false);
            return restult;
        }

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = this.Context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await this.Context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteAsync(T entity)
        {

            EntityEntry entityEntry = this.Context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await this.Context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
