using HouseRentWebApi.ApplicationLogic.CountryLogic.Command;
using HouseRentWebApi.ApplicationLogic.CountryLogic.Model;
using HouseRentWebApi.ApplicationLogic.CountryLogic.Queries;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class CountryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<CountryGridModel>>> GetAll()
        {
            var result = await Mediator.Send(new GetCountryGetAllQuery());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Upsert(UpsertCountryCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}