using SmartDevices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDevices.Controllers
{
    public class SmartCarController : Controller
    {
        private readonly SmartDeviceContext _context;

        public SmartCarController()
        {
            _context = new SmartDeviceContext();
        }


        // GET: SmartCar
        public ActionResult Index()
        {
            var cars = _context.Car.ToList();
            return View(cars);
        }

        // GET: SmartCar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SmartCar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmartCar/Create
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

        // GET: SmartCar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SmartCar/Edit/5
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

        // GET: SmartCar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SmartCar/Delete/5
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
