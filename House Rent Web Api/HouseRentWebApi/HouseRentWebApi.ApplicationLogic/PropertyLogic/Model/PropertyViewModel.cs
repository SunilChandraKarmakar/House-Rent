using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.Dynamic;

namespace HouseRentWebApi.ApplicationLogic.PropertyLogic.Model
{
    public class PropertyViewModel
    {
        public PropertyModel Model { get; set; }
        public PropertyGridModel GridModel { get; set; }
        public dynamic optionsDataSources { get; set; } = new ExpandoObject();
    }

    public class PropertyModel : IMapFrom<Property>
    {
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, PropertyModel>();
            profile.CreateMap<PropertyModel, Property>();
        }
    }

    public class PropertyGridModel : IMapFrom<Property>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellRent { get; set; }
        public string PropertyTypeName { get; set; }
        public string FurnishingTypeName { get; set; }
        public int Bhk { get; set; }
        public double Price { get; set; }
        public int BuildArea { get; set; }
        public int CarpetArea { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloor { get; set; }
        public bool IsReadyToMove { get; set; }
        public string MainEntrance { get; set; }
        public int Security { get; set; }
        public bool IsGated { get; set; }
        public int Maintenence { get; set; }
        public DateTime? EstPossessionOn { get; set; }
        public DateTime? PostedOn { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

        public Address Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, PropertyGridModel>()
                .ForMember(d => d.PropertyTypeName, s => s.MapFrom(m => m.PropertyType.Name))
                .ForMember(d => d.FurnishingTypeName, s => s.MapFrom(m => m.FurnishingType.Name))
                .ForMember(d => d.Address, s => s.MapFrom(m => m.Address))
                .ForMember(d => d.UserName, s => s.MapFrom(m => m.User.FullName));
        }
    }
}