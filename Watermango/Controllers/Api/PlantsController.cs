using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Watermango.Data;
using Watermango.Models;

namespace Watermango.Controllers.Api
{
    public class PlantsController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET api/plants
        public IHttpActionResult GetPlants()
        {
            return Ok(_context.Plants.ToList());
        }

        // GET api/plants/5
        public IHttpActionResult WaterPlant(int? id)
        {
            DateTime currentTime = DateTime.Now;
            var plant = _context.Plants.SingleOrDefault(p => p.Id == id);
            if (id == null || plant == null)
            {
                return BadRequest("Plant Id is not valid.");
            }
            double timeBetweenWatering = currentTime.Subtract(plant.LastWatered).TotalSeconds;
            if (timeBetweenWatering > 30)
            {
                plant.LastWatered = currentTime.AddSeconds(10);
                plant.Status = "Watered";
                _context.Entry(plant).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return Ok(_context.Plants.ToList());
        }
    }
}