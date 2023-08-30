namespace HouseRentWebApi.Domain
{
    public class Address
    {
        public Address()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}