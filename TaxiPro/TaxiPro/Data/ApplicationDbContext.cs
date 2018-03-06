using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaxiPro.Models;

namespace TaxiPro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         public DbSet<Student> Students { get; set; }
         public DbSet<StudentAnswer> StudentAnswers { get; set; }
         public DbSet<TestType> TestTypes { get; set; }
         public DbSet<Event> Events { get; set; }
         public DbSet<Option> Options { get; set; }
         public DbSet<Video> Videos { get; set; }
         public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
