﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours_App.Models
{
    public class Service
    {
        public string network { get; set; }
        public List<string> subNetwork { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public Category category { get; set; }
        public string postalCode { get; set; }
        public string visibility { get; set; }

        public Service(string _network, int _userId, string _description, string _title, Category _category, string _postalCode, string _visibility)
        {
            network = _network;
            subNetwork = new List<string>();
            userId = _userId;
            description = _description;
            title = _title;
            category = _category;
            postalCode = _postalCode;
            visibility = _visibility;
        }

    }
}