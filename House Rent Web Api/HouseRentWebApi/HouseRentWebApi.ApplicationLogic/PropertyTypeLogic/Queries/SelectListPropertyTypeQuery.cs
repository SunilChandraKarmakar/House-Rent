using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Shared.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Queries
{
    public class SelectListPropertyTypeQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListPropertyTypeQuery, List<SelectModel>>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<List<SelectModel>> Handle(SelectListPropertyTypeQuery request, CancellationToken cancellationToken)
            {
                List<SelectModel> getAllSelects = await _service.Context.PropertyTypes
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