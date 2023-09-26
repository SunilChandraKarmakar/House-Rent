using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Command;
using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Model;
using HouseRentWebApi.ApplicationLogic.FurnishingTypeLogic.Queries;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class FurnishingTypeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<FurnishingTypeGridModel>>> GetAll()
        {
            var result = await Mediator.Send(new GetFurnishingTypeGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FurnishingTypeViewModel>> Get(int id)
        {
            var vm = new FurnishingTypeViewModel
            {
                Model = await Mediator.Send(new GetFurnishingTypeDetailQuery { Id = id }),
            };

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertFurnishingTypeCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedFurnishingTypeId = await Mediator.Send(new DeleteFurnishingTypeCommand { Id = id });
            return Ok(deletedFurnishingTypeId);
        }
    }
}