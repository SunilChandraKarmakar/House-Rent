using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Queries
{
    public class GetPropertyTypeGetAllQuery : IRequest<ICollection<PropertyTypeModel>>
    {
        public class Handler : IRequestHandler<GetPropertyTypeGetAllQuery, ICollection<PropertyTypeModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<ICollection<PropertyTypeModel>> Handle(GetPropertyTypeGetAllQuery request,
                CancellationToken cancellationToken)
            {
                var propertyTypes = await _service.Context.PropertyTypes.Where(pt => !pt.IsDeleted).ToListAsync();
                var mapPropertyTypes = _service.Mapper.Map<ICollection<PropertyTypeModel>>(propertyTypes).ToList();

                return mapPropertyTypes;
            }
        }
    }
}