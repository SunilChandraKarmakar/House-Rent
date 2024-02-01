using HouseRentWebApi.ApplicationLogic.ImageUploderLogic.Command;
using HouseRentWebApi.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentWebApi.Controllers
{
    public class ImageUploadController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile formFile, int propertyId)
        {
            var upsertImageUploadCommand = new UpsertImageUploadCommand();
            var imageUploadResult = await upsertImageUploadCommand.UploadImage(formFile);

            if (imageUploadResult.Error != null)
                throw new Exception(imageUploadResult.Error.Message);

            return Ok("Image Upload Successfull.");
        }
    }
}