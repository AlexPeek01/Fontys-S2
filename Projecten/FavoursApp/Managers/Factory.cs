using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public enum SelectedRepo
    {
        RepoSet1,
    }
    public class Factory
    {
        Repos.Factory factory;
        public Factory()
        {
            factory = new Repos.Factory();
        }
        public INetworkRepo GetNetworkRepo(SelectedRepo reposet)
        {
            switch (reposet)
            {
                case SelectedRepo.RepoSet1:
                    return new NetworkRepo(factory.GetNetworkDAL(DataSource.sql));
                default:
                    throw new NotSupportedException();
            }
        }
        public IServiceRepo GetServiceRepo(SelectedRepo reposet)
        {
            switch (reposet)
            {
                case SelectedRepo.RepoSet1:
                    return new ServiceRepo(factory.GetServiceDAL(DataSource.sql));
                default:
                    throw new NotSupportedException();
            }
        }
        public IUserRepo GetUserRepo(SelectedRepo reposet)
        {
            switch (reposet)
            {
                case SelectedRepo.RepoSet1:
                    return new UserRepo(factory.GetUserDAL(DataSource.sql));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
