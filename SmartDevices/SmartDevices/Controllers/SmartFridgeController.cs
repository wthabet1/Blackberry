using SmartDevices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDevices.Controllers
{
    public class SmartFridgeController : Controller
    {
        private readonly SmartDeviceContext _context;

        public SmartFridgeController()
        {
            _context = new SmartDeviceContext();
        }

        // GET: SmartFridge
        public ActionResult Index()
        {
            var fridges = _context.Fridge.ToList();
            return View(fridges);
        }

        // GET: SmartFridge/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var fridge = _context.Fridge.Single(f => f.id == id);
                return View(fridge);
            }
            catch
            {
                //ViewBag.Error = e?.Message + ":" + e?.InnerException?.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: SmartFridge/Create
        public ActionResult Create()
        {
            Fridge newFridge = new Fridge();
            return View(newFridge);
        }

        // POST: SmartFridge/Create
        [HttpPost]
        public ActionResult Create(Fridge newFridge)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Fridge.Add(newFridge);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newFridge);
            }
        }

        // GET: SmartFridge/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var fridge = _context.Fridge.Single(f => f.id == id);
                return View(fridge);
            }
            catch
            {
                //ViewBag.Error = e?.Message + ":" + e?.InnerException?.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: SmartFridge/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Fridge modFridge)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fridgeToUpdate = _context.Fridge.Single(f => f.id == id);
                    if (TryUpdateModel(fridgeToUpdate))
                    {
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(modFridge);
            }
            catch
            {
                return View(modFridge);
            }
        }

        // GET: SmartFridge/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var fridge = _context.Car.Single(f => f.id == id);
                return View(fridge);
            }
            catch
            {
                //ViewBag.Error = e?.Message + ":" + e?.InnerException?.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: SmartFridge/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Fridge oldFridge)
        {
            try
            {
                // TODO: Add delete logic here
                var fridgeToDelete = _context.Fridge.Single(f => f.id == id);
                _context.Fridge.Remove(fridgeToDelete);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(oldFridge);
            }
        }
    }
}
