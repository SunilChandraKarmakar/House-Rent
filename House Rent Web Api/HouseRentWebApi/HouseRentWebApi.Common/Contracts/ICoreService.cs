using AutoMapper;

namespace HouseRentWebApi.Common.Contracts
{
    public interface ICoreService
    {
        ICoreDbContext Context { get; }
        IMapper Mapper { get; }
    }
}