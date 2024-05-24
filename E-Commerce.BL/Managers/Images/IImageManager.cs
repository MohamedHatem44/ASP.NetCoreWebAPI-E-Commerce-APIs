using E_Commerce.BL.Dtos.Images;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.BL.Managers.Images
{
    public interface IImageManager
    {
        UploadImageDto Upload(IFormFile file, string scheme, string host, string controllerName);
    }
}
