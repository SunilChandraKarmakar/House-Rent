using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Command
{
    public class DeleteFurnishingTypeCommand : FurnishingTypeModel, IRequest<int>
    {
        public class Handler : IRequestHandler<DeleteFurnishingTypeCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(DeleteFurnishingTypeCommand request, CancellationToken cancellationToken)
            {
                var existFurnishingType = await _service.Context.FurnishingTypes.FirstOrDefaultAsync(ft => ft.Id == request.Id);

                existFurnishingType.IsDeleted = true;
                existFurnishingType.DeletedDateTime = DateTime.Now;

                var deletedFurnishingType = _service.Mapper.Map<FurnishingTypeModel>(existFurnishingType);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return deletedFurnishingType.Id;
            }
        }
    }
}