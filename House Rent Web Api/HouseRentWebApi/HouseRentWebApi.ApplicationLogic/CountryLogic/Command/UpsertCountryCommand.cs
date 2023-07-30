using HouseRentWebApi.ApplicationLogic.CountryLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CountryLogic.Command
{
    public class UpsertCountryCommand : CountryModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertCountryCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(UpsertCountryCommand request, CancellationToken cancellationToken)
            {
                Country countryEntity;
                countryEntity = await _service.Context.Countries.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (countryEntity == null)
                {
                    countryEntity = new Country();
                    _service.Context.Countries.Add(countryEntity);
                }

                countryEntity = _service.Mapper.Map((CountryModel)request, countryEntity);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return countryEntity.Id;
            }
        }
    }
}