using HouseRentWebApi.ApplicationLogic.AddressLogic.Command;
using HouseRentWebApi.ApplicationLogic.AddressLogic.Model;
using HouseRentWebApi.ApplicationLogic.AddressLogic.Queries;
using HouseRentWebApi.ApplicationLogic.CityLogic.Queries;
using HouseRentWebApi.ApplicationLogic.CountryLogic.Queries;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class AddressController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<AddressGridModel>>> GetAll()
        {
            var result = await Mediator.Send(new GetAddressGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressViewModel>> Get(int id)
        {
            var vm = new AddressViewModel
            {
                Model = await Mediator.Send(new GetAddressDetailQuery { Id = id }),
            };

            vm.optionsDataSources.CitySelectList = Mediator.Send(new SelectListCityQuery()).Result;
            vm.optionsDataSources.CountrySelectList = Mediator.Send(new SelectListCountryQuery()).Result;

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertAddressCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedAddressId = await Mediator.Send(new DeleteAddressCommand { Id = id });
            return Ok(deletedAddressId);
        }
    }
}