using HouseRentWebApi.ApplicationLogic.PropertyLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyLogic.Command
{
    public class UpsertPropertyCommand : PropertyModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertPropertyCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(UpsertPropertyCommand request, CancellationToken cancellationToken)
            {
                Property propertyEntity;
                propertyEntity = await _service.Context.Properties.FirstOrDefaultAsync(p => p.Id == request.Id);

                if (propertyEntity == null)
                {
                    propertyEntity = new Property();
                    _service.Context.Properties.Add(propertyEntity);
                }

                propertyEntity = _service.Mapper.Map((PropertyModel)request, propertyEntity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return propertyEntity.Id;
            }
        }
    }
}