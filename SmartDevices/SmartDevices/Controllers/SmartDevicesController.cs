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
                sd.Name = "Smart Car";
                sd.ID = ++id;
                sd.Location = car.location;
                if (!String.IsNullOrEmpty(car.location))
                    sd.SensorsState = "Working";
                else
                    sd.SensorsState = "Not working";
                _lstSmartDevices.Add(sd);
            }

            var fridges = _context.Fridge.ToList();
            foreach (var fridge in fridges)
            {
                SmartDevice sd = new SmartDevice();
                sd.Name = "Smart Fridge";
                sd.ID = ++id;
                sd.Location = fridge.location;
                if (!String.IsNullOrEmpty(fridge.location))
                    sd.SensorsState = "Working";
                else
                    sd.SensorsState = "Not working";

                _lstSmartDevices.Add(sd);
            }

        }
        // GET: SmartDevices
        public ActionResult Index()
        {
            return View(_lstSmartDevices);
        }

        // GET: SmartDevices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SmartDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmartDevices/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SmartDevices/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SmartDevices/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SmartDevices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SmartDevices/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
