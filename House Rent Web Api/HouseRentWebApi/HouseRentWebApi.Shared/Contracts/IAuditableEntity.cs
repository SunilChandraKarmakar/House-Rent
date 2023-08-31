namespace HouseRentWebApi.Shared.Contracts
{
    public interface IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}