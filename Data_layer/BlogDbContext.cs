using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog
{
    // Context of DB
    public class BlogDbContext : DbContext 
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(x => x.Tags).WithMany(x => x.Topics)
                .Map(t => t.MapLeftKey("TopicID")
                    .MapRightKey("TagID")
                    .ToTable("TopicTag"));
        }
    }
}