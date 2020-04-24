using System;
using System.Collections.Generic;
using System.Text;

namespace Models
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
        public int GetServiceID()
        {
            return serviceId;
        }
        public int GetPostersID()
        {
            return postersId;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetDescription()
        {
            return description;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string[] GetImages()
        {
            return images;
        }
        public void SetImages(string[] images)
        {
            this.images = images;
        }
        public DateTime GetDate()
        {
            return date;
        }
        public void SetDate(DateTime date)
        {
            this.date = date;
        }
        public bool GetVisibility()
        {
            return visibility;
        }
        public void SetVisibility(bool visibility)
        {
            this.visibility = visibility;
        }
    }
}
