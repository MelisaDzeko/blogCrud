using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace blogCRUD.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [NotMapped]
        public List<string> TagList { get; set; }



        public Post() { }
        public Post(int id, string title, string description, string body)
        {
            Id = id;
            Slug = title.Replace(" ", "-");
            Title = title;
            Description = description;
            Body = body;
            CreatedAt = DateTime.Now;
        }
    }
}
