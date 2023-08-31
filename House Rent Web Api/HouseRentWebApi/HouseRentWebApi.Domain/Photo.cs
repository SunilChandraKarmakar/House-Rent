using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.Domain
{
    public class Photo : IAuditableEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Property Property { get; set; }
    }
}