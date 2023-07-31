using HouseRentWebApi.ApplicationLogic.CountryLogic.Model;
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.ApplicationLogic.CountryLogic.Command
{
    public class DeleteCountryCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteCountryCommand, int>
        {
            private readonly ICoreService _service;

            public Handler(ICoreService coreService)
            {
                _service = coreService;
            }

            public async Task<int> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                Country existCountry = await _service.Context.Countries.FirstOrDefaultAsync(c => c.Id == request.Id);

                existCountry.IsDeleted = true;
                existCountry.DeletedDateTime = DateTime.Now;

                CountryModel deletedCountry = _service.Mapper.Map<CountryModel>(existCountry);
                await _service.Context.SaveChangesAsync(cancellationToken);

                return deletedCountry.Id;
            }
        }
    }
}