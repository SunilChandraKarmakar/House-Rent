using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Command
{
    public class UpsertFurnishingTypeCommand : FurnishingTypeModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertFurnishingTypeCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(UpsertFurnishingTypeCommand request, CancellationToken cancellationToken)
            {
                FurnishingType FurnishingTypeEntity;
                FurnishingTypeEntity = await _service.Context.FurnishingTypes.FirstOrDefaultAsync(ft => ft.Id == request.Id);

                var existFurnishingTypeName = await _service.Context.FurnishingTypes
                                            .Where(ft => ft.Name.ToLower() == request.Name.ToLower())
                                            .Select(s => s.Name)
                                            .FirstOrDefaultAsync();

                if (FurnishingTypeEntity == null)
                {
                    if (!string.IsNullOrEmpty(existFurnishingTypeName))
                        throw new Exception("Furnishing Type name already exist!");

                    FurnishingTypeEntity = new FurnishingType();
                    _service.Context.FurnishingTypes.Add(FurnishingTypeEntity);
                }

                FurnishingTypeEntity = _service.Mapper.Map((FurnishingTypeModel)request, FurnishingTypeEntity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return FurnishingTypeEntity.Id;
            }
        }
    }
}