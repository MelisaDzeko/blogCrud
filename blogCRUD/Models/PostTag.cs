using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Models
{
    public class PostTag
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public string TagId { get; set; }

        public Tag Tag { get; set; }



        public PostTag() { }

        public PostTag(int id, int postId, string tagId)
        {
            Id = id;
            PostId = postId;
            TagId = tagId;
        }
    }
}
