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

        public string Name { get; set; }

        public string Type { get { return "Fridge"; } }

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