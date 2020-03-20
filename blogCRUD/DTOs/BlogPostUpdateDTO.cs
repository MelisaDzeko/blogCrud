using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.DTOs
{
    public class BlogPostUpdateDTO
    {
        public BlogPostUpdate blogPost { get; set; }


        public class BlogPostUpdate
        {
            public string title { get; set; }
        }
    }
}
