using AdditionalFiles.Interfaces.IDAL;
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
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@ServiceID", service.ServiceID},
                new string[] { "@NetworkID", service.NetworkID},
                new string[] { "@UserID", service.PostersID},
                new string[] { "@Title", service.Title},
                new string[] { "@Description", service.Description},
                new string[] { "@Image", service.Images},
                new string[] { "@Date", service.Date.ToString()},
                new string[] { "@Visibility", Convert.ToInt32(service.Visibility).ToString()},
                new string[] { "@Category", service.Category}
            };
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO services (ServiceID,NetworkID,UserID,Title,Description,Image,Date,Visibility,Category) VALUES(@ServiceID,@NetworkID,@UserID,@Title,@Description,@Image,@Date,@Visibility,@Category)", parameters);
        }
        // Methods regarding the services in a network
        public List<Service> GetServicesByNetworkID(string ID)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@NetworkID", ID },
            };
            List<string[]> networkData = SQLConnection.ExecuteSearchQueryWithArrayReturn($"SELECT * FROM services WHERE NetworkID=@NetworkID", parameters);
            List<Service> serviceList = new List<Service>();
            foreach (string[] data in networkData)
            {
                Service service = new Service();
                service.ServiceID = data[0];
                service.NetworkID = data[1];
                service.PostersID = data[2];
                service.Title = data[3];
                service.Description = data[4];
                service.Images = data[5];
                service.Date = Convert.ToDateTime(data[6]);
                service.Visibility = data[7] == "0" ? false : true;
                service.Category = data[8];
                serviceList.Add(service);
            }
            return serviceList;
        }
        public Service GetServiceDataById(string serviceID)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@ServiceID", serviceID },
            };
            string[] serviceData = SQLConnection.ExecuteSearchQuery("SELECT * FROM services WHERE ServiceID = @ServiceID", parameters).ToArray();
            return new Service()
            {
                ServiceID = serviceData[0],
                NetworkID = serviceData[1],
                PostersID = serviceData[2],
                Title = serviceData[3],
                Description = serviceData[4],
                Images = serviceData[5],
                Date = DateTime.Parse(serviceData[6]),
                Visibility = Convert.ToBoolean(Int32.Parse(serviceData[7])),
                Category = serviceData[8],
            };
        }
    }
}
