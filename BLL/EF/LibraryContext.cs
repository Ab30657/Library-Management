using Microsoft.EntityFrameworkCore;
using BLL.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace BLL.EF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Card)
                .WithOne(cd => cd.Student)
                .HasForeignKey<Card>(ad => ad.StudentId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"server=.;database=LibrarySystem;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";
                optionsBuilder.UseSqlServer(
                    connectionString,
                    options => options.EnableRetryOnFailure())
#pragma warning disable CS0618 // Type or member is obsolete
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }


    }
}
