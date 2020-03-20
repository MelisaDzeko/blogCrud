using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.DTOs
{
    public class BlogPostInsertDTO
    {
        public class BlogPostInsert
        {
            public BlogPost blogPost { get; set; }
        }

        public class BlogPost
        {
            public string title { get; set; }

            public string description { get; set; }

            public string body { get; set; }

            public List<string> tagList { get; set; }
        }
    }
}
