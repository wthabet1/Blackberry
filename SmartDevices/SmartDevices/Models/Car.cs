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

        public string Name { get; set; }

        public string Type
        {
            get { return "Car"; }
            //set { Type = value; }
        }

        [Display(Name = "Working?")]
        public string Status
        {
            get
            {
                Random rnd = new Random();
                int intWorkingLevel = rnd.Next(1, 100);
                if (intWorkingLevel < 25)
                    return false.ToString();
                return true.ToString();
            }
        }

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