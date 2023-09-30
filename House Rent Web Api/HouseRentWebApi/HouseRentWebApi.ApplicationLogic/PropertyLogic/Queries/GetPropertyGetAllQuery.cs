using HouseRentWebApi.ApplicationLogic.PropertyLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyLogic.Queries
{
    public class GetPropertyGetAllQuery : IRequest<ICollection<PropertyGridModel>>
    {
        public class Handler : IRequestHandler<GetPropertyGetAllQuery, ICollection<PropertyGridModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<ICollection<PropertyGridModel>> Handle(GetPropertyGetAllQuery request,
                CancellationToken cancellationToken)
            {
                var properties = await _service.Context.Properties
                                .Include(p => p.PropertyType)
                                .Include(p => p.FurnishingType)
                                .Include(p => p.Address)
                                    .ThenInclude(a => a.City)
                                .Include(p => p.Address)
                                    .ThenInclude(a => a.CountryId)
                                .Include(p => p.User)
                                .Where(c => !c.IsDeleted)
                                .ToListAsync();

                var mapProperties = _service.Mapper.Map<ICollection<PropertyGridModel>>(properties).ToList();
                return mapProperties;
            }
        }
    }
}