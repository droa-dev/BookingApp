namespace BookingApp.Domain.Core.Repositories
{
    public interface IEntityBase
    {
        int Id { get; set; }
        public DateTime? CreatedAt { get; set; }        
        public DateTime? LastModifiedByAt { get; set; }        
    }
}
