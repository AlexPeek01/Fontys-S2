using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoursApp.Models
{
    public class ServiceWithUser
    {
        public User user { get; private set; }
        public Service service { get; private set; }
        public ServiceWithUser(User _user, Service _service)
        {
            user = _user;
            service = _service;
        }
        public ServiceWithUser(){}
    }
}
