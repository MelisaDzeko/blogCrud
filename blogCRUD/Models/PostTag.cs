using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Models
{
    public class PostTag
    {
        public string PostId { get; set; }

        public Post Post { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
