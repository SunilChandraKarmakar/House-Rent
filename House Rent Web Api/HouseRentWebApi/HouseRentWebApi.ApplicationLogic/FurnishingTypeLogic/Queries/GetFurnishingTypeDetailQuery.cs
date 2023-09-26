using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Queries
{
    public class GetFurnishingTypeDetailQuery : IRequest<FurnishingTypeModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetFurnishingTypeDetailQuery, FurnishingTypeModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<FurnishingTypeModel> Handle(GetFurnishingTypeDetailQuery request, 
                CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new FurnishingTypeModel();

                var existFurnishingType = await _service.Context.FurnishingTypes
                                                .FirstOrDefaultAsync(ft => ft.Id == request.Id);

                return _service.Mapper.Map<FurnishingTypeModel>(existFurnishingType);
            }
        }
    }
}