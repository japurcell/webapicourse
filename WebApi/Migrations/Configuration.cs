namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleContext context)
        {
            context.Customers.AddOrUpdate(
                c => c.Name,
                new Customer {  Name = "Customer One" },
                new Customer { Name = "Customer Two" },
                new Customer { Name = "Customer Three" }
            );
        }
    }
}
