using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Queries
{
    public class GetFurnishingTypeGetAllQuery : IRequest<ICollection<FurnishingTypeModel>>
    {
        public class Handler : IRequestHandler<GetFurnishingTypeGetAllQuery, ICollection<FurnishingTypeModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<ICollection<FurnishingTypeModel>> Handle(GetFurnishingTypeGetAllQuery request,
                CancellationToken cancellationToken)
            {
                var furnishingTypes = await _service.Context.FurnishingTypes.Where(ft => !ft.IsDeleted).ToListAsync();
                var mapFurnishingTypes = _service.Mapper.Map<ICollection<FurnishingTypeModel>>(furnishingTypes).ToList();

                return mapFurnishingTypes;
            }
        }
    }
}