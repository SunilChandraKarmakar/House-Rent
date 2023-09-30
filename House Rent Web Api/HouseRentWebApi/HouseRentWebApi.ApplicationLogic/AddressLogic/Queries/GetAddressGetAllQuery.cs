using HouseRentWebApi.ApplicationLogic.AddressLogic.Model;
using HouseRentWebApi.Common.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.AddressLogic.Queries
{
    public class GetAddressGetAllQuery : IRequest<ICollection<AddressGridModel>>
    {
        public class Handler : IRequestHandler<GetAddressGetAllQuery, ICollection<AddressGridModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<ICollection<AddressGridModel>> Handle(GetAddressGetAllQuery request,
                CancellationToken cancellationToken)
            {
                var addresses = await _service.Context.Addresses
                                .Include(a => a.City)
                                .Include(a => a.Country)
                                .Where(c => !c.IsDeleted)
                                .ToListAsync();

                var mapAddresses = _service.Mapper.Map<ICollection<AddressGridModel>>(addresses).ToList();
                return mapAddresses;
            }
        }
    }
}