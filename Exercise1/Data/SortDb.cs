using Microsoft.EntityFrameworkCore;

namespace Exercise1
{
    public class SortDb : DbContext
    {
        public SortDb(DbContextOptions<SortDb> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static string ConnectionString => "DefaultConnection";
        public DbSet<Log> Log { get; set; }
        public DbSet<Storage> Storage { get; set; }
    }
}
