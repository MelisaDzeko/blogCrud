using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.DTOs
{
    public class BlogPostDTO
    {
        public string slug { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string body { get; set; }

        public List<string> tagList { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
