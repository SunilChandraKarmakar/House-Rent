using HouseRentWebApi.ApplicationLogic.PropertyLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyLogic.Queries
{
    public class GetPropertyDetailQuery : IRequest<PropertyModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetPropertyDetailQuery, PropertyModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<PropertyModel> Handle(GetPropertyDetailQuery request, CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new PropertyModel();

                var existProperty = await _service.Context.PropertyTypes.FirstOrDefaultAsync(p => p.Id == request.Id);
                return _service.Mapper.Map<PropertyModel>(existProperty);
            }
        }
    }
}