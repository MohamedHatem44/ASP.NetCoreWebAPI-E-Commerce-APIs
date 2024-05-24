using E_Commerce.BL.Dtos.Images;
using E_Commerce.BL.Managers.Images;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IImageManager _imageManager;
        /*------------------------------------------------------------------------*/
        public ImagesController(IImageManager imageManager)
        {
            _imageManager = imageManager;
        }
        /*------------------------------------------------------------------------*/
        // Create Image URL
        [HttpPost("Upload")]
        public ActionResult<UploadImageDto> CreateImageURL(IFormFile formFile, [FromForm] string controllerName)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return BadRequest("No file uploaded or file is empty.");
            }

            var scheme = Request.Scheme;
            var host = Request.Host.Value;

            var uploadResult = _imageManager.Upload(formFile, scheme, host, controllerName);
            if (!uploadResult.IsSuccess)
            {
               return BadRequest("Image upload failed: " + uploadResult.Message);
            }
            return uploadResult;
        }
        /*------------------------------------------------------------------------*/
    }
}
