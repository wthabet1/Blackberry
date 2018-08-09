using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartDevices.Models
{
    public class Car
    {
        //public Car()
        //{
        //    fluidLevel = string.Empty;
        //    tirePressure = float.NaN;
        //    engineTemperature = float.NaN;
        //    location = string.Empty;
        //}

        //public Car(Car other)
        //{
        //    fluidLevel = other.fluidLevel;
        //    tirePressure = other.tirePressure;
        //    engineTemperature = other.engineTemperature;
        //    location = other.location;
        //}

        [Key]
        public int id { get; set;  }

        public string fluidLevel { get; set; }

        public float tirePressure { get; set; }

        public float engineTemperature { get; set; }

        public string location { get; set; }
    }
}