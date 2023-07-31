using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Shared.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CountryLogic.Queries
{
    public class SelectListCountryQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListCountryQuery, List<SelectModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<List<SelectModel>> Handle(SelectListCountryQuery request, CancellationToken cancellationToken)
            {
                List<SelectModel> getAllSelects = await _service.Context.Countries
                                                    .Where(c => c.IsDeleted == false)
                                                    .Select(c => new SelectModel()
                                                    {
                                                        Id = c.Id,
                                                        Name = c.Name
                                                    }).ToListAsync();

                return getAllSelects;
            }
        }
    }
}