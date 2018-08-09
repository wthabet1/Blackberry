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

        public string Name { get; set; }

        public string Type { get { return "Car"; } }

        [Display(Name = "Fluid Level")]
        public string fluidLevel { get; set; }

        [Display(Name = "Tire Pressure")]
        public float tirePressure { get; set; }

        [Display(Name = "Engine Temperature")]
        public float engineTemperature { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }
    }
}