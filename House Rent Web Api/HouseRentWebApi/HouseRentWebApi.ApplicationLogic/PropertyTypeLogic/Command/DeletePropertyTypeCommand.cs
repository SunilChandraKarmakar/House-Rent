using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Command
{
    public class DeletePropertyTypeCommand : PropertyTypeModel, IRequest<int>
    {
        public class Handler : IRequestHandler<DeletePropertyTypeCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(DeletePropertyTypeCommand request, CancellationToken cancellationToken)
            {
                var existPropertyType = await _service.Context.PropertyTypes.FirstOrDefaultAsync(pt => pt.Id == request.Id);

                existPropertyType.IsDeleted = true;
                existPropertyType.DeletedDateTime = DateTime.Now;

                var deletedPropertyType = _service.Mapper.Map<PropertyTypeModel>(existPropertyType);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return deletedPropertyType.Id;
            }
        }
    }
}