using AdditionalFiles.Interfaces.IDAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class Factory
    {
        public INetworkDB GetNetworkDAL(string source)
        {
            switch (source)
            {
                case "Release":
                    return new NetworkDB();
                default:
                    throw new NotSupportedException();
            }
        }
        public IServiceDB GetServiceDAL(string source)
        {
            switch (source)
            {
                case "Release":
                    return new ServiceDB();
                default:
                    throw new NotSupportedException();
            }
        }
        public IUserDB GetUserDAL(string source)
        {
            switch (source)
            {
                case "Release":
                    return new UserDB();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
