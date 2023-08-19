using HouseRentWebApi.ApplicationLogic.AccountLogic.Command;
using HouseRentWebApi.ApplicationLogic.AccountLogic.Model;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserModel>> Registration(RegistrationCommand command)
        {
            var registerUser = await Mediator.Send(command);
            return Ok(registerUser);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserModel>> Login(LoginCommand command)
        {
            var loginUser = await Mediator.Send(command);
            return Ok(loginUser);
        }
    }
}