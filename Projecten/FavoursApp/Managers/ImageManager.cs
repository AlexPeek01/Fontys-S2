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

        public static string SaveImage(IFormFile image, IHostingEnvironment _hostingEnvironment)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploadedimages");
            if (image != null && image.Length > 0)
            {
                string imageID = IdentificationManager.GetUniqueKey();
                string filetype = '.' + image.ContentType.Split('/')[1];
                string filename = imageID + filetype;
                var filePath = Path.Combine(uploads, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyToAsync(fileStream);
                }
                return filename;
            }
            return null;
        }
    }
}
