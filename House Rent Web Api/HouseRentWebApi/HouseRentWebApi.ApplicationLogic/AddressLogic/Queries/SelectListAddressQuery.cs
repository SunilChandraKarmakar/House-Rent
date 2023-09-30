using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Shared.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.AddressLogic.Queries
{
    public class SelectListAddressQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListAddressQuery, List<SelectModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<List<SelectModel>> Handle(SelectListAddressQuery request, CancellationToken cancellationToken)
            {
                List<SelectModel> getAllSelects = await _service.Context.Addresses
                                                    .Where(c => c.IsDeleted == false)
                                                    .Select(c => new SelectModel()
                                                    {
                                                        Id = c.Id,
                                                        Name = c.AddressLineOne + c.AddressLineTwo
                                                    }).ToListAsync();

                return getAllSelects;
            }
        }
    }
}