using Core101.Model.Entity;
using Microsoft.EntityFrameworkCore;


namespace Core101.Model.DataContaxt
{
    public partial class Core101DataContext : DbContext
    {
        public Core101DataContext()
        {
        }

        public Core101DataContext(DbContextOptions<Core101DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
