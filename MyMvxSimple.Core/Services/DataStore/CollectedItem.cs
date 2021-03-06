﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services.DataStore
{
    public class CollectedItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Notes { get; set; }
        public DateTime WhenUtc { get; set; }
        public bool LocationKnown { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string ImagePath { get; set; }
    }
}
