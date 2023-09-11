using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Command;
using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Model;
using HouseRentWebApi.ApplicationLogic.PropertyTypeLogic.Queries;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PropertyTypeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<PropertyTypeGridModel>>> GetAll()
        {
            var result = await Mediator.Send(new GetPropertyTypeGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyTypeViewModel>> Get(int id)
        {
            PropertyTypeViewModel vm = new PropertyTypeViewModel
            {
                Model = await Mediator.Send(new GetPropertyTypeDetailQuery { Id = id }),
            };

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertPropertyTypeCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var deletedPropertyTypeId = await Mediator.Send(new DeletePropertyTypeCommand { Id = id });
            return Ok(deletedPropertyTypeId);
        }
    }
}