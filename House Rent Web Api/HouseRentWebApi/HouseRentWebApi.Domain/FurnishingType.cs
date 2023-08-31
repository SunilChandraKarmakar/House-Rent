using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.Domain
{
    public class FurnishingType : IAuditableEntity
    {
        public FurnishingType()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}