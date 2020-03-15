using blogCRUD.Context;
using blogCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.References
{
    public class UnitOfWorkRepo : IUnitOfWork
    {

        private readonly BlogContext _context;
        private IPost _postRepo;
        private ITag _tagRepo;

        public UnitOfWorkRepo(BlogContext context)
        {
            _context = context;
        }

        public IPost Post
        {
            get
            {
                return _postRepo = _postRepo ?? new PostRepo(_context);
            }
        }

        public ITag Tag
        {
            get
            {
                return _tagRepo = _tagRepo ?? new TagRepo(_context);
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
