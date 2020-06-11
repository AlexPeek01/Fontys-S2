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
    public enum SelectedManager
    {
        ManagerSet1,
    }
    public class Factory
    {
        Managers.Factory factory;
        public Factory()
        {
            factory = new Managers.Factory();
        }
        public INetworkManager GetNetworkManager(SelectedManager managerset)
        {
            switch (managerset)
            {
                case SelectedManager.ManagerSet1:
                    return new FavoursNetworkManager(factory.GetNetworkRepo(SelectedRepo.RepoSet1));
                default:
                    throw new NotSupportedException();
            }
        }
        public IServiceManager GetServiceManager(SelectedManager managerset)
        {
            switch (managerset)
            {
                case SelectedManager.ManagerSet1:
                    return new FavoursServiceManager(factory.GetServiceRepo(SelectedRepo.RepoSet1));
                default:
                    throw new NotSupportedException();
            }
        }
        public IUserManager GetUserManager(SelectedManager managerset)
        {
            switch (managerset)
            {
                case SelectedManager.ManagerSet1:
                    return new FavoursUserManager(factory.GetUserRepo(SelectedRepo.RepoSet1));
                default:
                    throw new NotSupportedException();
            }
        }
        public IImageManager GetImageManager(SelectedManager managerset)
        {
            switch (managerset)
            {
                case SelectedManager.ManagerSet1:
                    return new ImageManager();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
