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
            DateTime currentTime = DateTime.Now;
            List<Plant> plants = _context.Plants.ToList();
            foreach (Plant plant in plants){
                double timeSinceLastWatering = currentTime.Subtract(plant.LastWatered).TotalMinutes;
                if(timeSinceLastWatering > 1)
                {
                    plant.Status = "Needs water!";
                    _context.Entry(plant).State = EntityState.Modified;
                }
            }
            _context.SaveChanges();
            return Ok(_context.Plants.ToList());
        }

        // PUT api/plants/5
        [HttpPut]
        [Route("api/plants/{id}")]
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
                plant.LastWatered = currentTime;
                plant.Status = "Watered";
            }
            _context.SaveChanges();
            return Ok(_context.Plants.ToList());
        }
    }
}