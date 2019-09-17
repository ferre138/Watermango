using System;
using System.Collections.Generic;
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
        public IEnumerable<Plant> GetPlants()
        {
            return _context.Plants.ToList();
        }

        // GET api/plants/5

    }
}