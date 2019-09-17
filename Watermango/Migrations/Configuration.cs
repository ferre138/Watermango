namespace Watermango.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Watermango.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Watermango.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Watermango.Data.ApplicationDbContext context)
        {
            context.Plants.AddOrUpdate(x => x.Id,
                new Plant { Id = 1, Name = "Plant 1", Status = "Needs water", LastWatered = new DateTime(2018, 5, 1) },
                new Plant { Id = 2, Name = "Plant 2", Status = "Needs water", LastWatered = new DateTime(2018, 4, 4) },
                new Plant { Id = 3, Name = "Plant 3", Status = "Needs water", LastWatered = new DateTime(2018, 5, 13) },
                new Plant { Id = 4, Name = "Plant 4", Status = "Needs water", LastWatered = new DateTime(2018, 6, 6) }
              );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
