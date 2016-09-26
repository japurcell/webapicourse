namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SampleContext : DbContext
    {
        public SampleContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}