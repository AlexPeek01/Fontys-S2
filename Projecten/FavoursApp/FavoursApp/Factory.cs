using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using Managers;
using Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavoursApp
{
    public class Factory
    {
        Managers.Factory factory;
        public Factory()
        {
            factory = new Managers.Factory();
        }
        public INetworkManager GetNetworkManager(string managerset)
        {
            switch (managerset)
            {
                case "Release":
                    return new FavoursNetworkManager(factory.GetNetworkRepo(managerset), GetIdentificationManager(managerset));
                default:
                    throw new NotSupportedException();
            }
        }
        public IServiceManager GetServiceManager(string managerset)
        {
            switch (managerset)
            {
                case "Release":
                    return new FavoursServiceManager(factory.GetServiceRepo(managerset));
                default:
                    throw new NotSupportedException();
            }
        }
        public IUserManager GetUserManager(string managerset)
        {
            switch (managerset)
            {
                case "Release":
                    return new FavoursUserManager(factory.GetUserRepo(managerset));
                default:
                    throw new NotSupportedException();
            }
        }
        public IImageManager GetImageManager(string managerset)
        {
            switch (managerset)
            {
                case "Release":
                    return new ImageManager();
                default:
                    throw new NotSupportedException();
            }
        }
        public IIdentificationManager GetIdentificationManager(string managerset)
        {
            switch (managerset)
            {
                case "Release":
                    return new IdentificationManager();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
