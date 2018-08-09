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
            try
            {
                var car = _context.Car.Single(c => c.id == id);
                return View(car);
            }
            catch (Exception e)
            {
                //ViewBag.Error = e?.Message + ":" + e?.InnerException?.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: SmartCar/Create
        public ActionResult Create()
        {
            Car newCar = new Car();
            return View(newCar);
        }

        // POST: SmartCar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car newCar)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Car.Add(newCar);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newCar);
            }
        }

        // GET: SmartCar/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var car = _context.Car.Single(c => c.id == id);
                return View(car);
            }
            catch (Exception e)
            {
                //ViewBag.Error = e?.Message + ":" + e?.InnerException?.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: SmartCar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car modCar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var carToUpdate = _context.Car.Single(c => c.id == id);
                    if (TryUpdateModel(carToUpdate))
                    {
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }   
                }
                return View(modCar);
            }
            catch
            {
                return View(modCar);
            }
        }

        // GET: SmartCar/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var car = _context.Car.Single(c => c.id == id);
                return View(car);
            }
            catch
            {
                //ViewBag.Error = e?.Message + ":" + e?.InnerException?.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: SmartCar/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car oldCar)
        {
            try
            {
                // TODO: Add delete logic here
                var carToDelete = _context.Car.Single(c => c.id == id);
                _context.Car.Remove(carToDelete);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(oldCar);
            }
        }
    }
}
