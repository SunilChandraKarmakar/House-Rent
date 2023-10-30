using AutoMapper;
using HouseRentWebApi.ApplicationLogic.AddressLogic.Model;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Please, provied project name.")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, select sell rent.")]
        public int SellRent { get; set; }

        [Required(ErrorMessage = "Please, select property type.")]
        public int PropertyTypeId { get; set; }

        [Required(ErrorMessage = "Please, select furnishing type.")]
        public int FurnishingTypeId { get; set; }

        [Required(ErrorMessage = "Please, provied bhk.")]
        public int Bhk { get; set; }

        [Required(ErrorMessage = "Please, provied price.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please, provied build area.")]
        public int BuildArea { get; set; }

        [Required(ErrorMessage = "Please, provied carpet area.")]
        public int CarpetArea { get; set; }

        [Required(ErrorMessage = "Please, provied floor no.")]
        public int FloorNo { get; set; }

        [Required(ErrorMessage = "Please, provied total floor.")]
        public int TotalFloor { get; set; }
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Please, select ready to move or not.")]
        public bool IsReadyToMove { get; set; }

        public int Security { get; set; }

        [Required(ErrorMessage = "Please, select gated.")]
        public bool IsGated { get; set; }

        [Required(ErrorMessage = "Please, provied maintenence.")]
        public int Maintenence { get; set; }

        [Required(ErrorMessage = "Please, select date.")]
        public DateTime? EstPossessionOn { get; set; }
        public DateTime? PostedOn { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public AddressModel Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, PropertyModel>()
                .ForMember(m => m.Address, s => s.MapFrom(m => m.Address));
            profile.CreateMap<PropertyModel, Property>()
                .ForMember(d => d.Address, s => s.MapFrom(m => m.Address));
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
        public int Security { get; set; }
        public bool IsGated { get; set; }
        public int Maintenence { get; set; }
        public DateTime? EstPossessionOn { get; set; }
        public DateTime? PostedOn { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

        public AddressViewModel Address { get; set; }
        public ICollection<PhotoViewModel> Photos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, PropertyGridModel>()
                .ForMember(d => d.PropertyTypeName, s => s.MapFrom(m => m.PropertyType.Name))
                .ForMember(d => d.FurnishingTypeName, s => s.MapFrom(m => m.FurnishingType.Name))
                .ForMember(d => d.Address, s => s.MapFrom(m => m.Address))
                .ForMember(d => d.UserName, s => s.MapFrom(m => m.User.FullName))
                .ForMember(d => d.Photos, s => s.MapFrom(m => m.Photos));
        }

        public class AddressModel : IMapFrom<Address>
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Please, provied address line one.")]
            [StringLength(200, MinimumLength = 2)]
            public string AddressLineOne { get; set; }
            public string AddressLineTwo { get; set; }

            [Required(ErrorMessage = "Please, select country.")]
            public int CountryId { get; set; }

            [Required(ErrorMessage = "Please, select city.")]
            public int CityId { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Address, AddressModel>();
                profile.CreateMap<AddressModel, Address>();
            }
        }

        public class AddressViewModel : IMapFrom<Address>
        {
            public int Id { get; set; }
            public string AddressLineOne { get; set; }
            public string AddressLineTwo { get; set; }
            public string CountryName { get; set; }
            public string CityName { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Address, AddressViewModel>()
                    .ForMember(d => d.CountryName, s => s.MapFrom(m => m.Country.Name))
                    .ForMember(d => d.CityName, s => s.MapFrom(m => m.City.Name));
            }
        }

        public class PhotoViewModel : IMapFrom<Photo>
        {
            public int Id { get; set; }
            public string Url { get; set; }
            public int PropertyId { get; set; }
            public bool IsDefault { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Photo, PhotoViewModel>();
                profile.CreateMap<PhotoViewModel, Photo>();
            }
        }
    }
}