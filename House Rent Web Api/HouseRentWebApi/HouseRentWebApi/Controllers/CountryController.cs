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
    }
}