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
        public IHttpActionResult Get(int id)
        {
            try
            {
                var car = _context.Car.Single(c => c.id == id);
                return Ok(car);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                                            Request.CreateErrorResponse((HttpStatusCode)500,
                                            new HttpError(e?.Message + ":" + e?.InnerException?.Message)));
            }
        }

        // POST: api/Car
        [HttpPost]
        public string Post([FromBody] Car newCar)
        {
            try
            {
                if (newCar != null)
                {
                    _context.Car.Add(newCar);
                    _context.SaveChanges();
                    return "New car with id " + newCar.id + " is created";
                }

                return "New car is not valid.";
            }
            catch (Exception e)
            {
                return e?.Message + ":" + e?.InnerException?.Message;
            }
        }

        // PUT: api/Car/5
        public IHttpActionResult Put(int id, [FromBody] Car modCar)
        {
            try
            {
                if (modCar != null)
                {
                    var car = _context.Car.Single(c => c.id == id);
                    if (car != null)
                    {
                        car = modCar;
                        _context.SaveChanges();
                        return Ok(car);
                    }
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                                          Request.CreateErrorResponse((HttpStatusCode)500,
                                          new HttpError(e?.Message + ":" + e?.InnerException?.Message)));
            }

        }

        // DELETE: api/Car/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var car = _context.Car.Single(c => c.id == id);
                _context.Car.Remove(car);
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                                         Request.CreateErrorResponse((HttpStatusCode)500,
                                         new HttpError(e?.Message + ":" + e?.InnerException?.Message)));
            }

        }
    }
}
