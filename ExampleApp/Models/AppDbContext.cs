using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired();
                entity.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired();
                entity.Property(x => x.BirthDate).HasColumnName("birth_date").HasColumnType("date");
            });
        }
    }
}
