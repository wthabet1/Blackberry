using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SmartDevices.Models
{
    public class SmartDeviceContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Fridge> Fridge { get; set; }
        public SmartDeviceContext()
        {

        }
    }
}