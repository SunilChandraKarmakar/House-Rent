using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.Domain
{
    public class Country : IAuditableEntity
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}