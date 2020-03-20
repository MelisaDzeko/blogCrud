using blogCRUD.Context;
using blogCRUD.Interfaces;
using blogCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.References
{
    public class TagRepo : ITag
    {
        private readonly BlogContext _context;

        public TagRepo(BlogContext context)
        {
            _context = context;
        }

        public List<Tag> GetAll()
        {
            List<Tag> tags = _context.Tags.ToList();

            return tags;
        }
    }
}
