using HouseRentWebApi.ApplicationLogic.AddressLogic.Queries;
using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Queries;
using HouseRentWebApi.ApplicationLogic.PropertyLogic.Command;
using HouseRentWebApi.ApplicationLogic.PropertyLogic.Model;
using HouseRentWebApi.ApplicationLogic.PropertyLogic.Queries;
using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Queries;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class PropertyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<PropertyGridModel>>> GetAll()
        {
            var result = await Mediator.Send(new GetPropertyGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyViewModel>> Get(int id)
        {
            var vm = new PropertyViewModel
            {
                Model = await Mediator.Send(new GetPropertyDetailQuery { Id = id }),
            };

            vm.optionsDataSources.PropertyTypeSelectList = Mediator.Send(new SelectListPropertyTypeQuery()).Result;
            vm.optionsDataSources.FurnishingTypeSelectList = Mediator.Send(new SelectListFurnishingTypeQuery()).Result;
            vm.optionsDataSources.AddressSelectList = Mediator.Send(new SelectListAddressQuery()).Result;

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertPropertyCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedPropertyId = await Mediator.Send(new DeletePropertyCommand { Id = id });
            return Ok(deletedPropertyId);
        }
    }
}