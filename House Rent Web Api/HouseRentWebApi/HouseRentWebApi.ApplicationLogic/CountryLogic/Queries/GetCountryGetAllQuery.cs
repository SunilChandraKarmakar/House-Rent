using HouseRentWebApi.ApplicationLogic.CountryLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CountryLogic.Queries
{
    public class GetCountryGetAllQuery : IRequest<ICollection<CountryGridModel>>
    {
        public class Handler : IRequestHandler<GetCountryGetAllQuery, ICollection<CountryGridModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<ICollection<CountryGridModel>> Handle(GetCountryGetAllQuery request, 
                CancellationToken cancellationToken)
            {
                var countries = await _service.Context.Countries.ToListAsync();
                var mapCountries = _service.Mapper.Map<ICollection<CountryGridModel>>(countries).ToList();

                return mapCountries;
            }
        }
    }
}