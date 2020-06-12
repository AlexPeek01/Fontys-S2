using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class Factory
    {
        Repos.Factory factory;
        public Factory()
        {
            factory = new Repos.Factory();
        }
        public INetworkRepo GetNetworkRepo(string reposet)
        {
            switch (reposet)
            {
                case "Release":
                    return new NetworkRepo(factory.GetNetworkDAL(reposet));
                default:
                    throw new NotSupportedException();
            }
        }
        public IServiceRepo GetServiceRepo(string reposet)
        {
            switch (reposet)
            {
                case "Release":
                    return new ServiceRepo(factory.GetServiceDAL(reposet));
                default:
                    throw new NotSupportedException();
            }
        }
        public IUserRepo GetUserRepo(string reposet)
        {
            switch (reposet)
            {
                case "Release":
                    return new UserRepo(factory.GetUserDAL(reposet));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
