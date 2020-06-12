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
            if(!String.IsNullOrEmpty(path) && !String.IsNullOrEmpty(filename))
            {
                var uploads = Path.Combine(path, "uploadedimages");
                return Path.Combine(uploads, filename);
            }
            return null;
        }
        public string GetImageName(string imagetype)
        {
            // Set imagename to UniqueKey + the image's filetype
            if (imagetype != null && imagetype.Length > 0)
            {
                string imageID = IdentificationHelper.GetUniqueKey();
                string filetype = '.' + imagetype;
                string filename = imageID + filetype;
                return filename;
            }
            return null;
        }

    }
}
