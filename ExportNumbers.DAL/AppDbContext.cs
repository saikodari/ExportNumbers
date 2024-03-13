using ExportNumbers.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExportNumbers.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<NumberSequence> NumberSequences { get; set; }
    }
}
