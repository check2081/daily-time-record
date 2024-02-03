using Microsoft.EntityFrameworkCore;

namespace TimePulse.Models
{
    public class RecordContext : DbContext
    {
        public RecordContext(DbContextOptions<RecordContext> options)
                : base(options)
        {
        }

        public DbSet<Record> Record { get; set; } = null!;
    }
}
