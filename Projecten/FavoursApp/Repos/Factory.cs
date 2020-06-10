using AdditionalFiles.Interfaces.IDAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public enum DataSource
    {
        sql,
        //memory
    }
    public class Factory
    {
        public INetworkDB GetNetworkDAL(DataSource source)
        {
            switch (source)
            {
                case DataSource.sql:
                    return new NetworkDB();
                //case DataSource.memory:
                //    return new NetworkMemoryContext();
                default:
                    throw new NotSupportedException();
            }
        }
        public IServiceDB GetServiceDAL(DataSource source)
        {
            switch (source)
            {
                case DataSource.sql:
                    return new ServiceDB();
                //case DataSource.memory:
                //    return new ServiceMemoryContext();
                default:
                    throw new NotSupportedException();
            }
        }
        public IUserDB GetUserDAL(DataSource source)
        {
            switch (source)
            {
                case DataSource.sql:
                    return new UserDB();
                //case DataSource.memory:
                //    return new UserMemoryContext();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
