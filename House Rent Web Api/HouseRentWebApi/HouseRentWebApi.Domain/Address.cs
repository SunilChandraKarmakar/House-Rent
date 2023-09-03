using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.Domain
{
    public class Address : IAuditableEntity
    {
        public Address()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public PropertyType City { get; set; }
        public Country Country { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}