using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IServiceDB
    {
        void InsertNewServiceData(Service service, string datestring);
    }
}
