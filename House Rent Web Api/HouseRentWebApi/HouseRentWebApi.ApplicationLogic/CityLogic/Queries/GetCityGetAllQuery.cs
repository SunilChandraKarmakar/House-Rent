using HouseRentWebApi.ApplicationLogic.CityLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CityLogic.Queries
{
    public class GetCityGetAllQuery : IRequest<ICollection<CityGridModel>>
    {
        public class Handler : IRequestHandler<GetCityGetAllQuery, ICollection<CityGridModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<ICollection<CityGridModel>> Handle(GetCityGetAllQuery request,
                CancellationToken cancellationToken)
            {
                var cities = await _service.Context.Cities.Include(c => c.Country).Where(c => !c.IsDeleted).ToListAsync();
                var mapCountries = _service.Mapper.Map<ICollection<CityGridModel>>(cities).ToList();

                return mapCountries;
            }
        }
    }
}