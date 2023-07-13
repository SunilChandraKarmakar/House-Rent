using AutoMapper;

namespace HouseRentWebApi.Shared.Contracts
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}