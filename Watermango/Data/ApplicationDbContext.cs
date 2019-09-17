using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Watermango.Models;

namespace Watermango.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("SQLConnectionString")
        {
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<Plant> Plants { get; set; }
    }
}