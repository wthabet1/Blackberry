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

        [Display(Name = "Temperature")]
        public float temperature { get; set; }

        [Display(Name = "Ice Level")]
        public string iceLevel { get; set; }

        [Display(Name = "Defrost Alarm")]
        public bool defrostAlarm { get; set; }

        [Display(Name = "Water Leaks")]
        public bool waterLeaks { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }
    }
}