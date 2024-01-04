using Microsoft.EntityFrameworkCore;

namespace BarBalanceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }

        public DbSet<Revenue> Revenues { get; set; }
    }
}
