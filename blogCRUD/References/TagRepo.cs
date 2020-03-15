using blogCRUD.Context;
using blogCRUD.Interfaces;
using blogCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.References
{
    public class TagRepo: ITag
    {

        private readonly BlogContext _context;

        public TagRepo(BlogContext context)
        {
            _context = context;
        }

        public List<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(int Id)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }

        public void Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

    }
}
