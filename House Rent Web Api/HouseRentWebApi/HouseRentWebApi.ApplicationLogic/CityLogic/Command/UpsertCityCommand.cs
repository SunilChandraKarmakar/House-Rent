using HouseRentWebApi.ApplicationLogic.CityLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CityLogic.Command
{
    public class UpsertCityCommand : CityModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertCityCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(UpsertCityCommand request, CancellationToken cancellationToken)
            {
                City cityEntity;
                cityEntity = await _service.Context.Cities.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (cityEntity == null)
                {
                    cityEntity = new City();
                    _service.Context.Cities.Add(cityEntity);
                }

                cityEntity = _service.Mapper.Map((CityModel)request, cityEntity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return cityEntity.Id;
            }
        }
    }
}