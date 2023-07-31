using HouseRentWebApi.ApplicationLogic.CityLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CityLogic.Command
{
    public class DeleteCityCommand : CityModel, IRequest<int>
    {
        public class Handler : IRequestHandler<DeleteCityCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var existCity = await _service.Context.Cities.FirstOrDefaultAsync(c => c.Id == request.Id);

                existCity.IsDeleted = true;
                existCity.DeletedDateTime = DateTime.Now;

                var deletedCountry = _service.Mapper.Map<CityModel>(existCity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return deletedCountry.Id;
            }
        }
    }
}