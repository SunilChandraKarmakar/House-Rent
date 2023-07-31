using HouseRentWebApi.ApplicationLogic.CityLogic.Command;
using HouseRentWebApi.ApplicationLogic.CityLogic.Model;
using HouseRentWebApi.ApplicationLogic.CityLogic.Queries;
using HouseRentWebApi.ApplicationLogic.CountryLogic.Queries;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class CityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<CityGridModel>>> GetAll()
        {
            var result = await Mediator.Send(new GetCityGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityViewModel>> Get(int id)
        {
            CityViewModel vm = new CityViewModel
            {
                Model = await Mediator.Send(new GetCityDetailQuery { Id = id }),
            };

            vm.optionsDataSources.CountrySelectList = Mediator.Send(new SelectListCountryQuery()).Result;
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertCityCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedCountryId = await Mediator.Send(new DeleteCityCommand { Id = id });
            return Ok(deletedCountryId);
        }
    }
}