using HouseRentWebApi.ApplicationLogic.AddressLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.AddressLogic.Command
{
    public class UpsertAddressCommand : AddressModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertAddressCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(UpsertAddressCommand request, CancellationToken cancellationToken)
            {
                Address addressEntity;
                addressEntity = await _service.Context.Addresses.FirstOrDefaultAsync(a => a.Id == request.Id);

                if (addressEntity == null)
                {
                    addressEntity = new Address();
                    _service.Context.Addresses.Add(addressEntity);
                }

                addressEntity = _service.Mapper.Map((AddressModel)request, addressEntity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return addressEntity.Id;
            }
        }
    }
}