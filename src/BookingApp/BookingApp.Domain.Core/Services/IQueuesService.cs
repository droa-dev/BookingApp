namespace BookingApp.Domain.Core.Services
{
    public interface IQueuesService
    {
        Task QueueAsync<T>(string queueName, T item);
    }
}
