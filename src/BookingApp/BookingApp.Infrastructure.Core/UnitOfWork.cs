using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure.Core
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookingAppDbContext _context;
        private bool _disposed;

        public UnitOfWork(BookingAppDbContext context) => _context = context;
        public void Dispose() => this.Dispose(true);

        public async Task<int> Save()
        {
            int affectedRows = await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in _context.ChangeTracker.Entries<IEntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedByAt = DateTime.UtcNow;
                        break;
                }
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._context.Dispose();
            }

            this._disposed = true;
        }
    }
}
