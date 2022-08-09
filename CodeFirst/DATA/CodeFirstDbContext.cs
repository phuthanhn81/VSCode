using DATA.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATA
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options)
                    : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(n => n.ID);
                builder.Property(n => n.Name).HasColumnType("nvarchar(100)");
                builder.HasOne(n => n.Category)
                       .WithOne(n => n.Product)
                       .HasForeignKey<Product>(n => n.CategoryID);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.HasKey(n => n.ID);
                builder.Property(n => n.Name).HasColumnType("nvarchar(100)");
            });
        }
    }
}