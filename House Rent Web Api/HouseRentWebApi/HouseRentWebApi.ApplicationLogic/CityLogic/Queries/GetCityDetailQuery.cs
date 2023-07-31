using HouseRentWebApi.ApplicationLogic.CityLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CityLogic.Queries
{
    public class GetCityDetailQuery : IRequest<CityModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCityDetailQuery, CityModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<CityModel> Handle(GetCityDetailQuery request, CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new CityModel();

                City existCity = await _service.Context.Cities.FirstOrDefaultAsync(c => c.Id == request.Id);

                return _service.Mapper.Map<CityModel>(existCity);
            }
        }
    }
}