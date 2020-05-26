using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ServiceDB : IServiceDB
    {
        public void InsertNewServiceData(Service service, string datestring)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO services (ServiceID,NetworkID,UserID,Title,Description,Image,Date,Visibility,Category) VALUES('{service.ServiceID}','{service.NetworkID}','{service.PostersID}','{service.Title}','{service.Description}','{service.Images}','{datestring}','{Convert.ToInt32(service.Visibility)}','{service.Category}')");
        }
    }
}
