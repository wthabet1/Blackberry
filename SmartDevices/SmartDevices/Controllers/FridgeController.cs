using SmartDevices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartDevices.Controllers
{
    public class FridgeController : ApiController
    {
        private readonly SmartDeviceContext _context;

        public FridgeController()
        {
            _context = new SmartDeviceContext();
        }

        // GET: api/Fridge
        public IEnumerable<Fridge> Get()
        {
            return _context.Fridge.ToList();
        }

        // GET: api/Fridge/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var fridge = _context.Fridge.Single(f => f.id == id);
                return Ok(fridge);
            }
            catch (Exception e)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                                            Request.CreateErrorResponse((HttpStatusCode)500,
                                            new HttpError(e?.Message + ":" + e?.InnerException?.Message)));
            }
        }

        // POST: api/Fridge
        public string Post([FromBody] Fridge newFridge)
        {
            try
            {
                if (newFridge != null)
                {
                    _context.Fridge.Add(newFridge);
                    _context.SaveChanges();
                    return "New fridge with id " + newFridge.id + " is created";
                }

                return "New fridge is not valid.";
            }
            catch (Exception e)
            {
                return e?.Message + ":" + e?.InnerException?.Message;
            }
        }

        // PUT: api/Fridge/5
        public IHttpActionResult Put(int id, [FromBody] Fridge modFridge)
        {
            try
            {
                if (modFridge != null)
                {
                    var fridge = _context.Fridge.Single(f => f.id == id);
                    if (fridge != null)
                    {
                        fridge = modFridge;
                        _context.SaveChanges();
                        return Ok();
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

        // DELETE: api/Fridge/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var fridge = _context.Fridge.Single(f => f.id == id);
                _context.Fridge.Remove(fridge);
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
