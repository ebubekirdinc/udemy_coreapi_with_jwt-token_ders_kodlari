using Microsoft.EntityFrameworkCore;

namespace UdemyApiWithToken.Domain
{
    public partial class UdemyApiWithTokenDBContext : DbContext
    {
        public UdemyApiWithTokenDBContext()
        {
        }

        public UdemyApiWithTokenDBContext(DbContextOptions<UdemyApiWithTokenDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}