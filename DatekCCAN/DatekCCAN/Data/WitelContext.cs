using DatekCCAN.Models;
using Microsoft.EntityFrameworkCore;

namespace DatekCCAN.Data
{
    public class WitelContext : DbContext
    {
        public WitelContext(DbContextOptions<WitelContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Datek> Dateks { get; set; }
        public DbSet<Delete> Deletes { get; set; }
        public DbSet<CCAN> CCANs { get; set; }
        public DbSet<Modify> Modifys { get; set; }
        public DbSet<WAN> WANs { get; set; }
        public DbSet<WantTSEL> WantTSELs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Datek>().ToTable("Datek");
            modelBuilder.Entity<Delete>().ToTable("Delete");
            modelBuilder.Entity<CCAN>().ToTable("CCAN");
            modelBuilder.Entity<Modify>().ToTable("Modify");
            modelBuilder.Entity<WAN>().ToTable("WAN");
            modelBuilder.Entity<WantTSEL>().ToTable("WantTSEL");
        }
    }
}