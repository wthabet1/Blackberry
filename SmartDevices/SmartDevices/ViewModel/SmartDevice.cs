using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartDevices.ViewModel
{
    public class SmartDevice
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int ID { get; set; }

        public int dbId { get; set; }

        public string Location { get; set; }

        [Display(Name = "Sensor State")]
        public string SensorsState { get; set; }
    }
}