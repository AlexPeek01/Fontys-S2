using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class Service
    {
        private int serviceId;
        private int postersId;
        private string title;
        private string description;
        private string[] images;
        private DateTime date;
        private bool visibility;

        public Service(int _postersId, string _title, string _description)
        {
            images = new string[9];
            this.postersId = _postersId;
            this.title = _title;
            this.description = _description;
        }
    }
}
