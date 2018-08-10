using SmartDevices.Models;
using SmartDevices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDevices.Controllers
{
    public class SmartDevicesController : Controller
    {
        private readonly SmartDeviceContext _context;
        private List<SmartDevice> _lstSmartDevices; 

        public SmartDevicesController()
        {
            _context = new SmartDeviceContext();
            _lstSmartDevices = new List<SmartDevice>();
            int id = 0; 

            var cars = _context.Car.ToList();
            foreach(var car in cars)
            {
                SmartDevice sd = new SmartDevice();
                sd.Name = car.Name;
                sd.ID = ++id;
                sd.dbId = car.id;
                sd.Type = car.Type;
                sd.Location = car.location;
                sd.Status = car.Status;
                _lstSmartDevices.Add(sd);
            }

            var fridges = _context.Fridge.ToList();
            foreach (var fridge in fridges)
            {
                SmartDevice sd = new SmartDevice();
                sd.Name = fridge.Name;
                sd.ID = ++id;
                sd.Type = fridge.Type;
                sd.dbId = fridge.id;
                sd.Location = fridge.location;
                sd.Status = fridge.Status;

                _lstSmartDevices.Add(sd);
            }

        }
        // GET: SmartDevices
        public ActionResult Index()
        {
            Response.AppendHeader("Refresh", "15");
            return View(_lstSmartDevices);
        }
    }
}
