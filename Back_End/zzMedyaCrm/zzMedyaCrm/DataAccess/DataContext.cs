using Microsoft.EntityFrameworkCore;
using zzMedyaCrm.Entities;

namespace zzMedyaCrm.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }


    }
}
