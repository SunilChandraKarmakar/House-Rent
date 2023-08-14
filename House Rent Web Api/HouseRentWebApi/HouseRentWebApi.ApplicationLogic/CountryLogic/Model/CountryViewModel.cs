using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace HouseRentWebApi.ApplicationLogic.CountryLogic.Model
{
    public class CountryViewModel
    {
        public CountryModel Model { get; set; }
        public CountryGridModel GridModel { get; set; }
        public dynamic optionsDataSources { get; set; } = new ExpandoObject();
    }

    public class CountryModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied Country Name.")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryModel>();
            profile.CreateMap<CountryModel, Country>();
        }
    }

    public class CountryGridModel : IMapFrom<Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryGridModel>();
            profile.CreateMap<CountryGridModel, Country>();
        }
    }
}