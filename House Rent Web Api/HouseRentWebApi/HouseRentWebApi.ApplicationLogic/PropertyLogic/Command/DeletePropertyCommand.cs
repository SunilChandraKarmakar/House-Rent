using HouseRentWebApi.ApplicationLogic.PropertyLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyLogic.Command
{
    public class DeletePropertyCommand : PropertyModel, IRequest<int>
    {
        public class Handler : IRequestHandler<DeletePropertyCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
            {
                var existProperty = await _service.Context.Properties.FirstOrDefaultAsync(p => p.Id == request.Id);

                existProperty.IsDeleted = true;
                existProperty.DeletedDateTime = DateTime.Now;

                var deletedProperty = _service.Mapper.Map<PropertyModel>(existProperty);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return deletedProperty.Id;
            }
        }
    }
}