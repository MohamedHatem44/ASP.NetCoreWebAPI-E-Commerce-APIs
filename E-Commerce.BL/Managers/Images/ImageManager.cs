using E_Commerce.BL.Dtos.Images;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.BL.Managers.Images
{
    public class ImageManager : IImageManager
    {
        public UploadImageDto Upload(IFormFile file, string scheme, string host, string controllerName)
        {
            var extension = Path.GetExtension(file.FileName);
            var allowedExtenstions = new string[] { ".png", ".jpg", ".svg" };

            bool isExtensionAllowed = allowedExtenstions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return new UploadImageDto(false, "Extension is not valid");
            }

            bool isSizeAllowed = file.Length is > 0 and <= 5_000_000;
            if (!isSizeAllowed)
            {
                return new UploadImageDto(false, "Size is not allowed");
            }

            var newFileName = $"{controllerName}_{Guid.NewGuid()}{extension}";
            var imagePath = Path.Combine(Environment.CurrentDirectory, "Images", controllerName);
            var fullFilePath = Path.Combine(imagePath, newFileName);

            Directory.CreateDirectory(imagePath);

            using var stream = new FileStream(fullFilePath, FileMode.Create);
            file.CopyTo(stream);

            var url = $"{scheme}://{host}/Images/{controllerName}/{newFileName}";
            return new UploadImageDto(true, "Success", url);
        }
    }
}
