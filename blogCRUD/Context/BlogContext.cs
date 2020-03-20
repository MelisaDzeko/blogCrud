using blogCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PostTag>()

             .HasOne(s => s.Post)

             .WithMany()

             .HasForeignKey(s => s.PostId)

             .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PostTag>()

               .HasOne(so => so.Tag)

               .WithMany()

               .HasForeignKey(so => so.TagId)

               .OnDelete(DeleteBehavior.Restrict);




            modelBuilder.Seed();
        }
    }
}
