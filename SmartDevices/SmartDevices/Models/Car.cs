using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartDevices.Models
{
    public class Car
    {
        [Key]
        public int id { get; set;  }

        public string fluidLevel { get; set; }

        public float tirePressure { get; set; }

        public float engineTemperature { get; set; }

        public string location { get; set; }
    }
}