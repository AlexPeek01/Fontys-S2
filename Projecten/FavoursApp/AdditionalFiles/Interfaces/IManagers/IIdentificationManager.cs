using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IManagers
{
    public interface IIdentificationManager
    {
        string GetUniqueKey();
        string Encrypt(string data);
    }
}
