using HouseRentWebApi.ApplicationLogic.PropertyLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyLogic.Queries
{
    public class GetPropertyDetailQuery : IRequest<PropertyGridModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetPropertyDetailQuery, PropertyGridModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<PropertyGridModel> Handle(GetPropertyDetailQuery request, CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new PropertyGridModel();

                var existProperty = await _service.Context.Properties
                                    .Include(p => p.PropertyType)
                                    .Include(p => p.FurnishingType)
                                    .Include(p => p.Address)
                                        .ThenInclude(a => a.City)
                                    .Include(p => p.Address)
                                        .ThenInclude(a => a.Country)
                                    .FirstOrDefaultAsync(p => p.Id == request.Id);

                var mapExistProperty = _service.Mapper.Map<PropertyGridModel>(existProperty);
                return mapExistProperty;
            }
        }
    }
}