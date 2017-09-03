using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mainweb.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mainweb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Lesson> Lessons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<Excercise>().HasMany<ExcerciseItem>().WithOne().OnDelete(DeleteBehavior.Cascade);
           // builder.Entity<ExcerciseItem>().HasMany<CorrectResponse>().WithOne().OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<mainweb.Models.Excercise> Excercise { get; set; }

        public DbSet<mainweb.Models.ProgressViewModel> ProgressViewModel { get; set; }
    }
}
