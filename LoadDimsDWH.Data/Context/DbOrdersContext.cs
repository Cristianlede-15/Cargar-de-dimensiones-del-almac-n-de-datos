using Microsoft.EntityFrameworkCore;
using LoadDimsDWH.Data.Models;

namespace LoadDimsDWH.Data.Context
{
    public class DbOrdersContext : DbContext
    {
        public DbOrdersContext(DbContextOptions<DbOrdersContext> options) : base(options) { }

        public DbSet<DimCategories> DimCategories { get; set; }
        public DbSet<DimCustomers> DimCustomers { get; set; }
        public DbSet<DimEmployees> DimEmployees { get; set; }
        public DbSet<DimProducts> DimProducts { get; set; }
        public DbSet<DimShippers> DimShippers { get; set; }
    }
}
