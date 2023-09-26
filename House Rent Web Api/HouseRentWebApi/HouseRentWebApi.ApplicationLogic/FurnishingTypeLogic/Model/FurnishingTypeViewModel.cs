using AutoMapper;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Contracts;

namespace HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Model
{
    public class FurnishingTypeViewModel
    {
        public FurnishingTypeModel Model { get; set; }
        public FurnishingTypeGridModel GridModel { get; set; }
    }

    public class FurnishingTypeModel : IMapFrom<FurnishingType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FurnishingType, FurnishingTypeModel>();
            profile.CreateMap<FurnishingTypeModel, FurnishingType>();
        }
    }

    public class FurnishingTypeGridModel : IMapFrom<FurnishingType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FurnishingType, FurnishingTypeGridModel>();
            profile.CreateMap<FurnishingTypeGridModel, FurnishingType>();
        }
    }
}