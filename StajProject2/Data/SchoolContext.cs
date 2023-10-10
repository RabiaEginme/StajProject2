using System.Data.Common;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using StajProject2.Entities;
using Microsoft.EntityFrameworkCore;


namespace StajProject2.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasMany(s => s.Addresses)
                        .WithOne(c => c.Student)
                        .HasForeignKey(c => c.StudentId);
            //modelBuilder.Entity<Student>()
            //            .HasMany(a => a.Lessons)
            //            .WithMany(b => b.Students);
                            


            base.OnModelCreating(modelBuilder);
        }

        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RFDJL3E;Database=StajProjectNew;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
} 
