using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.Domain
{
    public class City : IAuditableEntity
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Country Country { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}