using AdditionalFiles.Interfaces.IManagers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class ImageManager : IImageManager
    {
        public string GetFilePath(string path, string filename)
        {
            var uploads = Path.Combine(path, "uploadedimages");
            return Path.Combine(uploads, filename);
        }
        public string GetImageName(string image)
        {
            // Set imagename to UniqueKey + the image's filetype
            if (image != null && image.Length > 0)
            {
                string imageID = IdentificationHelper.GetUniqueKey();
                string filetype = '.' + image;
                string filename = imageID + filetype;
                return filename;
            }
            return null;
        }

    }
}
