using CRUDModal2.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDModal2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
