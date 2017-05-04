namespace WebApi
{
    using System.Data.Entity;
    using Models;

    public class EfContext : DbContext
    {
        public EfContext() 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext, Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .HasRequired<Company>(s => s.Company)
                .WithMany(s => s.Users);
        }
    }
}