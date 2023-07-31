using HouseRentWebApi.ApplicationLogic.CountryLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CountryLogic.Queries
{
    public class GetCountryDetailQuery : IRequest<CountryModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCountryDetailQuery, CountryModel>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<CountryModel> Handle(GetCountryDetailQuery request, CancellationToken cancellationToken)
            {
                if (int.IsNegative(request.Id))
                    return new CountryModel();

                Country existCountry = await _service.Context.Countries.FirstOrDefaultAsync(c => c.Id == request.Id);

                return _service.Mapper.Map<CountryModel>(existCountry);
            }
        }
    }
}