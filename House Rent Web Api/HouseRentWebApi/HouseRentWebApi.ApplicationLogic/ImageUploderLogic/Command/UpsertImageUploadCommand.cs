using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace HouseRentWebApi.ApplicationLogic.ImageUploderLogic.Command
{
    public class UpsertImageUploadCommand
    {
        private readonly Cloudinary _cloudinary;

        public UpsertImageUploadCommand()
        {
            var account = new Account("dcoir2b6f", "955435979675946", "Tvb0t99tPbc7cyb7ABxzLEMNAls");
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadImage(IFormFile image)
        {
            var imageUploadResult = new ImageUploadResult();

            // Check image is not null
            if(image.Length > 0 && image != null)
            {
                using var stream = image.OpenReadStream();
                var imageUploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.Name, stream),
                    Transformation = new Transformation().Height(500).Width(800)
                };

                imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);
            }

            return imageUploadResult;
        }
    }
}