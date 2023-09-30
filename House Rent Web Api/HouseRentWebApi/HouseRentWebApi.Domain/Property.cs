namespace HouseRentWebApi.Domain
{
    public class Property
    {
        public Property()
        {
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SellRent { get; set; }
        public int PropertyTypeId { get; set; }
        public int FurnishingTypeId { get; set; }
        public int Bhk { get; set; }
        public double Price { get; set; }
        public int BuildArea { get; set; }
        public int CarpetArea { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloor { get; set; }
        public int AddressId { get; set; }
        public bool IsReadyToMove { get; set; }
        public string MainEntrance { get; set; }
        public int Security { get; set; }
        public bool IsGated { get; set; }
        public int Maintenence { get; set; }
        public DateTime? EstPossessionOn { get; set; }
        public DateTime? PostedOn { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Address Address { get; set; }
        public FurnishingType FurnishingType { get; set; }
        public PropertyType PropertyType { get; set; }
        public User User { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}