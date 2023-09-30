using HouseRentWebApi.ApplicationLogic.AddressLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.AddressLogic.Queries
{
    public class GetAddressDetailQuery : IRequest<AddressModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetAddressDetailQuery, AddressModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<AddressModel> Handle(GetAddressDetailQuery request, CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new AddressModel();

                var existAddress = await _service.Context.Addresses.FirstOrDefaultAsync(a => a.Id == request.Id);
                return _service.Mapper.Map<AddressModel>(existAddress);
            }
        }
    }
}