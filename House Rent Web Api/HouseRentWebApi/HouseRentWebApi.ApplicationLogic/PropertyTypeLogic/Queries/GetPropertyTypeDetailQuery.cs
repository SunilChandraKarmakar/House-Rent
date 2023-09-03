using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Queries
{
    public class GetPropertyTypeDetailQuery : IRequest<PropertyTypeModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetPropertyTypeDetailQuery, PropertyTypeModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<PropertyTypeModel> Handle(GetPropertyTypeDetailQuery request, CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new PropertyTypeModel();

                PropertyType existPropertyType = await _service.Context.PropertyTypes
                                                .FirstOrDefaultAsync(pt => pt.Id == request.Id);

                return _service.Mapper.Map<PropertyTypeModel>(existPropertyType);
            }
        }
    }
}