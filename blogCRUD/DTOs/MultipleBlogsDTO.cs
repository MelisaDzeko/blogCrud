using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.DTOs
{
    public class MultipleBlogsDTO
    {
        public List<BlogPostDTO> blogPosts { get; set; }

        public int postsCount { get; set; }
    }
}
