using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class ImageHelper
    {
        public static async Task SaveImage(IFormFile image, IHostingEnvironment _hostingEnvironment, string filename)
        {
            // Set file directory
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploadedimages");
            if (image != null && image.Length > 0)
            {
                // Save image
                var filePath = Path.Combine(uploads, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
        }
        public static string GetImageName(IFormFile image)
        {
            // Set imagename to UniqueKey + the image's filetype
            if (image != null && image.Length > 0)
            {
                string imageID = IdentificationHelper.GetUniqueKey();
                string filetype = '.' + image.ContentType.Split('/')[1];
                string filename = imageID + filetype;
                return filename;
            }
            return null;
        }

    }
}
