using LoadDWVentas.Data.Entities.Northwind;
using LoadDWVentas.Data.Entities.Norwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDimsDWH.Data.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }



        #region"Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        #endregion

        }
    }
}
