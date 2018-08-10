using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Owin;
using Hangfire;
using System.Data.Entity;
using SmartDevices.Models;

namespace SmartDevices
{
    public class HangfireContext : DbContext
    {
        public HangfireContext() : base("HangfireContext")  // Remove "name="
        {
            Database.SetInitializer<HangfireContext>(null);
            Database.CreateIfNotExists();
        }
    }

    public class WebApiApplication : System.Web.HttpApplication
    {

        private BackgroundJobServer _backgroundJobServer;

        public void OperateFridges()
        {
            SmartDeviceContext _context = new SmartDeviceContext();
            Random rnd = new Random();
            int operation = rnd.Next(1, 8);
            int iceLevel = rnd.Next(0, 10);
            int fluidLevel = rnd.Next(1, 5);
            int temperature = rnd.Next(-4, 40);
            bool newValue;

            var fridges = _context.Fridge.ToList();
            if (fridges.Count == 0)
            {
                Fridge newFridge = new Fridge();
                newFridge.iceLevel = iceLevel.ToString();

                Boolean.TryParse(rnd.Next(0, 1).ToString(), out newValue);
                newFridge.waterLeaks = newValue;
                Boolean.TryParse(rnd.Next(0, 1).ToString(), out newValue);
                newFridge.defrostAlarm = newValue;
                newFridge.temperature = temperature;
                newFridge.location = "Location-" + rnd.Next(1000000).ToString();
                newFridge.Name = "Fridge-" + rnd.Next(1000000).ToString();
                _context.Fridge.Add(newFridge);
                _context.SaveChanges();

            }

            foreach (var fridge in fridges)
            {
                try
                {
                    if (operation >= 1 && operation <= 3)
                    {
                        _context.Fridge.Remove(fridge);
                        _context.SaveChanges();
                        break;
                    }
                    else if (operation >= 4 && operation <= 5)
                    {
                        Fridge newFridge = new Fridge();
                        newFridge.temperature = temperature;
                        newFridge.iceLevel = iceLevel.ToString();
                        Boolean.TryParse(rnd.Next(0, 1).ToString(), out newValue);
                        newFridge.defrostAlarm = newValue;
                        Boolean.TryParse(rnd.Next(0, 1).ToString(), out newValue);
                        newFridge.waterLeaks = newValue;
                        newFridge.location = "Location-" + rnd.Next(1000000).ToString();
                        newFridge.Name = "Fridge-" + rnd.Next(1000000).ToString();
                        _context.Fridge.Add(newFridge);
                        _context.SaveChanges();
                    }
                    else if (operation >= 6 && operation <= 8)
                    {
                        var fridgeToUpdate = _context.Fridge.Single(c => c.id == fridge.id);
                        fridgeToUpdate.temperature = temperature;
                        fridgeToUpdate.iceLevel = iceLevel.ToString();
                        Boolean.TryParse(rnd.Next(0, 1).ToString(), out newValue);
                        fridgeToUpdate.defrostAlarm = newValue;
                        Boolean.TryParse(rnd.Next(0, 1).ToString(), out newValue);
                        fridgeToUpdate.waterLeaks = newValue;

                        _context.Fridge.Remove(fridgeToUpdate);
                        _context.SaveChanges();
                        _context.Fridge.Add(fridgeToUpdate);
                        _context.SaveChanges();
                    }
                }
                catch
                {
                    return;
                }

            }
        }
        public void OperateCars()
        {
            SmartDeviceContext _context = new SmartDeviceContext();
            Random rnd = new Random();
            int operation = rnd.Next(1, 8);
            int temp = rnd.Next(15, 32);
            int fluidLevel = rnd.Next(1, 5);
            int tirePressure = rnd.Next(11, 40);

            var cars = _context.Car.ToList();
            if (cars.Count == 0)
            {
                Car newCar = new Car();
                newCar.engineTemperature = temp;
                newCar.fluidLevel = fluidLevel.ToString();
                newCar.tirePressure = tirePressure;
                newCar.location = "Location-" + rnd.Next(1000000).ToString();
                newCar.Name = "Car-" + rnd.Next(1000000).ToString();
                _context.Car.Add(newCar);
                _context.SaveChanges();
            }

            foreach (var car in cars)
            {
                try
                {
                    if (operation >= 1 && operation <= 3)
                    {
                        _context.Car.Remove(car);
                        _context.SaveChanges();
                        break;
                    }
                    else if (operation >= 4 && operation <= 5)
                    {
                        Car newCar = new Car();
                        newCar.engineTemperature = temp;
                        newCar.fluidLevel = fluidLevel.ToString();
                        newCar.tirePressure = tirePressure;
                        newCar.location = "Location-" + rnd.Next(1000000).ToString();
                        newCar.Name = "Car-" + rnd.Next(1000000).ToString();
                        _context.Car.Add(newCar);
                        _context.SaveChanges();
                    }
                    else if (operation >= 6 && operation <= 8)
                    {
                        var carToUpdate = _context.Car.Single(c => c.id == car.id);
                        carToUpdate.engineTemperature = temp;
                        carToUpdate.fluidLevel = fluidLevel.ToString();
                        carToUpdate.tirePressure = tirePressure;

                        _context.Car.Remove(car);
                        _context.SaveChanges();
                        _context.Car.Add(carToUpdate);
                        _context.SaveChanges();
                    }
                }
                catch
                {
                    return;
                }

            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var db = new HangfireContext();
            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage(db.Database.Connection.ConnectionString);
            _backgroundJobServer = new BackgroundJobServer();

            //Run this job every egiht hours
            RecurringJob.AddOrUpdate(() => OperateCars(), Cron.HourInterval(8));

            //Run this job every three hours
            RecurringJob.AddOrUpdate(() => OperateFridges(), Cron.Minutely);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _backgroundJobServer.Dispose();
        }
    }
}
