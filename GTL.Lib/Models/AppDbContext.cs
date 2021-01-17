using GTL.Lib.Models.Portfolio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTL.Lib.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Portfolio
        public DbSet<Project> Project { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ProjectTag> ProjectTag { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Tag>()
                .HasIndex(i => i.Name)
                .IsUnique();

            builder.Entity<ProjectTag>()
                .HasIndex(p => new { p.TagId, p.ProjectId }).IsUnique();
        }
    }
}
