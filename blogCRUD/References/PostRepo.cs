using blogCRUD.Context;
using blogCRUD.Interfaces;
using blogCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.References
{
    public class PostRepo : IPost
    {
        private readonly BlogContext _context;

        public PostRepo(BlogContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(string Id)
        {
            return _context.Posts.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);

        }
    }
}
