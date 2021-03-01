using Kutuphane.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Data
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext(DbContextOptions<KutuphaneContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KutuphaneContext).Assembly);
        }
    }
}
