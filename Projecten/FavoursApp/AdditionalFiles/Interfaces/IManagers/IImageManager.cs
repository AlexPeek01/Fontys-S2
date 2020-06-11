using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalFiles.Interfaces.IManagers
{
    public interface IImageManager
    {
        string GetFilePath(string path, string filename);
        string GetImageName(string image);
    }
}
