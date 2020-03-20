using blogCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)

        {
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag("iOs"));
            tags.Add(new Tag("Gazzda"));
            tags.Add(new Tag("AR"));

            Post post = new Post(
                1, 
                "augmented-reality-ios-application", 
                "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", 
                "The app is simple to use, and will help you decide on your best furniture fit."
                );
            Post post2 = new Post(
          2,
          "augmented-reality-ios-application-2",
          "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
          "The app is simple to use, and will help you decide on your best furniture fit."
          );

            List<PostTag> postTags = new List<PostTag>();
            postTags.Add(new PostTag(1, 1, "iOs"));
            postTags.Add(new PostTag(2, 1, "AR"));
            postTags.Add(new PostTag(3, 2, "iOs"));
            postTags.Add(new PostTag(4, 2, "AR"));
            postTags.Add(new PostTag(5, 2, "Gazzda"));


            modelBuilder.Entity<Post>().HasData(post);

            modelBuilder.Entity<Post>().HasData(post2);

            modelBuilder.Entity<Tag>().HasData(tags.ToArray());

            modelBuilder.Entity<PostTag>().HasData(postTags.ToArray());









        }
    }
}

