using SmartDevices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartDevices.Controllers
{
    public class CarController : ApiController
    {
        private readonly SmartDeviceContext _context;

        public CarController()
        {
            _context = new SmartDeviceContext();
        }

        // GET: api/Car
        public IEnumerable<Car> Get()
        {
            return _context.Car.ToList();
        }

        // GET: api/Car/5
        public Car Get(int id)
        {
            var car = _context.Car.Single(c => c.id == id);
            return car;
        }

        // POST: api/Car
        [HttpPost]
        public void Post([FromBody] Car newCar)
        {
            if (newCar != null)
            {
                _context.Car.Add(newCar);
                _context.SaveChanges();
            }
        }

        // PUT: api/Car/5
        public void Put(int id, [FromBody] Car modCar)
        {
            var car = _context.Car.Single(c => c.id == id);
            if (car != null)
            {
                car.engineTemperature = modCar.engineTemperature;
                car.fluidLevel = modCar.fluidLevel;
                car.tirePressure = modCar.tirePressure;
                car.location = modCar.location;
                _context.SaveChanges();
            }
        }

        // DELETE: api/Car/5
        public void Delete(int id)
        {
            var car = _context.Car.Single(c => c.id == id);
            _context.Car.Remove(car);
            _context.SaveChanges();
        }
    }
}
