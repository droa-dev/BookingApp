namespace BookingApp.Domain.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Save();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
