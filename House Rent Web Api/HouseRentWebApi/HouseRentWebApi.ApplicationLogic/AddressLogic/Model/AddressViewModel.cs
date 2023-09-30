using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.Dynamic;

namespace HouseRentWebApi.ApplicationLogic.AddressLogic.Model
{
    public class AddressViewModel
    {
        public AddressModel Model { get; set; }
        public AddressGridModel GridModel { get; set; }
        public dynamic optionsDataSources { get; set; } = new ExpandoObject();
    }

    public class AddressModel : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressModel>();
            profile.CreateMap<AddressModel, Address>();
        }
    }

    public class AddressGridModel : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressGridModel>()
                .ForMember(d => d.CityName, s => s.MapFrom(m => m.City.Name))
                .ForMember(d => d.CountryName, s => s.MapFrom(m => m.Country.Name));
        }
    }
}