using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Models
{
    public class Tag
    {
        [Key]
        public string TagId { get; set; }



        public Tag() { }

        public Tag(string id)
        {
            TagId = id;
        }
    }
}
