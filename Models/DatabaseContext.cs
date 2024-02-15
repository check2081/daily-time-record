using Microsoft.EntityFrameworkCore;

namespace TimePulse.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
        }

        public DbSet<Record> Record { get; set; } = null!;
    }
}
