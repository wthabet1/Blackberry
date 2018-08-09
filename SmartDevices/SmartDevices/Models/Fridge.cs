using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartDevices.Models
{
    public class Fridge
    {
        [Key]
        public int id { get; set; }

        public float temperature { get; set; }

        public string iceLevel { get; set; }

        public bool defrostAlarm { get; set; }

        public bool waterLeaks { get; set; }

        public string location { get; set; }
    }
}