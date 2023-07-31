using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.Dynamic;

namespace HouseRentWebApi.ApplicationLogic.CityLogic.Model
{
    public class CityViewModel
    {
        public CityModel Model { get; set; }
        public CityGridModel GridModel { get; set; }
        public dynamic optionsDataSources { get; set; } = new ExpandoObject();
    }

    public class CityModel : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityModel>();
            profile.CreateMap<CityModel, City>();
        }
    }

    public class CityGridModel : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityGridModel>()
                .ForMember(d => d.CountryName, s => s.MapFrom(m => m.Country.Name));
            profile.CreateMap<CityGridModel, City>();
        }
    }
}