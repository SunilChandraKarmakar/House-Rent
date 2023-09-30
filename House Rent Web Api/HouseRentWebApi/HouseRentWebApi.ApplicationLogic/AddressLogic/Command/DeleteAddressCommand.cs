using HouseRentWebApi.ApplicationLogic.AddressLogic.Model;
using HouseRentWebApi.ApplicationLogic.CityLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.AddressLogic.Command
{
    public class DeleteAddressCommand : CityModel, IRequest<int>
    {
        public class Handler : IRequestHandler<DeleteAddressCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var existAddress = await _service.Context.Addresses.FirstOrDefaultAsync(a => a.Id == request.Id);

                existAddress.IsDeleted = true;
                existAddress.DeletedDateTime = DateTime.Now;

                var deletedAddress = _service.Mapper.Map<AddressModel>(existAddress);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return deletedAddress.Id;
            }
        }
    }
}