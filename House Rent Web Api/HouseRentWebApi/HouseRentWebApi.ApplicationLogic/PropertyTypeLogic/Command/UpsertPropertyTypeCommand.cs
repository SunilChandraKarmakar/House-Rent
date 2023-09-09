using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Command
{
    public class UpsertPropertyTypeCommand : PropertyTypeModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertPropertyTypeCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(UpsertPropertyTypeCommand request, CancellationToken cancellationToken)
            {
                PropertyType propertyTypeEntity;
                propertyTypeEntity = await _service.Context.PropertyTypes.FirstOrDefaultAsync(p => p.Id == request.Id);
                
                var existPropertyTypeName = await _service.Context.PropertyTypes
                                            .Where(pt => pt.Name.ToLower() == request.Name.ToLower())
                                            .Select(s => s.Name)
                                            .FirstOrDefaultAsync();

                if (propertyTypeEntity == null)
                {
                    if (!string.IsNullOrEmpty(existPropertyTypeName))
                        throw new Exception("Property Type name already exist!");

                    propertyTypeEntity = new PropertyType();
                    _service.Context.PropertyTypes.Add(propertyTypeEntity);
                }

                propertyTypeEntity = _service.Mapper.Map((PropertyTypeModel)request, propertyTypeEntity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return propertyTypeEntity.Id;
            }
        }
    }
}