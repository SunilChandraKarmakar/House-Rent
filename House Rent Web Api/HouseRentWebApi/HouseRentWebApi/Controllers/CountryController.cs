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

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryViewModel>> Get(int id)
        {
            CountryViewModel vm = new CountryViewModel
            {
                Model = await Mediator.Send(new GetCountryDetailQuery { Id = id }),
            };

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertCountryCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedCountryId = await Mediator.Send(new DeleteCountryCommand { Id = id });
            return Ok(deletedCountryId);
        }
    }
}