namespace BookingApp.Domain.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Save(CancellationToken cancellationToken = default);        
    }
}
