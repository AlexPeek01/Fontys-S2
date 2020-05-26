using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class ImageManager
    {
        public static async Task SaveImage(IFormFile image, IHostingEnvironment _hostingEnvironment, string filename)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploadedimages");
            if (image != null && image.Length > 0)
            {
                
                var filePath = Path.Combine(uploads, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
        }
        public static string GetImageName(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                string imageID = IdentificationManager.GetUniqueKey();
                string filetype = '.' + image.ContentType.Split('/')[1];
                string filename = imageID + filetype;
                return filename;
            }
            return null;
        }

    }
}
