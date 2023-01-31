using AngularCRUDApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularCRUDApi.DAL
{
    public class SqlDatabaseContext:DbContext
    {
        public SqlDatabaseContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }

    }
}
