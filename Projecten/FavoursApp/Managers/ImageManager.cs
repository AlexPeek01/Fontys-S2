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
            // Input checks
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Path can't be null or empty");
            if (string.IsNullOrEmpty(filename)) throw new ArgumentException("Filename can't be null or empty");

            var uploads = Path.Combine(path, "uploadedimages");
            return Path.Combine(uploads, filename);
        }
        public string GetImageName(string imagetype)
        {
            // Input checks
            if (string.IsNullOrEmpty(imagetype)) throw new ArgumentException("Imagetype can't be null or empty");

            // Set imagename to UniqueKey + the image's filetype
            string imageID = new IdentificationManager().GetUniqueKey();
            string filetype = '.' + imagetype;
            string filename = imageID + filetype;
            return filename;
        }

    }
}
