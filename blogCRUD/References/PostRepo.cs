using blogCRUD.Context;
using blogCRUD.Interfaces;
using blogCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            List<Post> posts = _context.Posts.ToList();

            foreach (var item in posts)
            {
                item.TagList = _context.PostTag.Where(a => a.PostId == item.Id).Select(x => x.TagId).ToList();
            }

            return posts;
        }

        public Post GetPost(string slug)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Slug == slug);

            post.TagList = _context.PostTag.Where(a => a.PostId == post.Id).Select(x => x.TagId).ToList();

            return post;
        }

        public List<Post> Search(string tag)
        {

            List<Post> postLists = _context.PostTag.Where(x => x.TagId == tag).Select(a => a.Post).OrderByDescending(x => x.CreatedAt).ToList();

            foreach (Post postList in postLists)
            {
                postList.TagList = _context.PostTag.Where(b => b.PostId == postList.Id).Select(l => l.TagId).ToList();
            }

            return postLists;
        }

        public void Insert(Post post)
        {
            if (post.TagList != null)
            {
                foreach (var item in post.TagList)
                {
                    var tag = _context.Tags.Where(x => x.TagId == item).FirstOrDefault();
                    if (tag == null)
                    {
                        Tag newTag = new Tag(item);
                        _context.Tags.Add(newTag);
                        _context.SaveChanges();
                    }
                }
            }

            var createdPost = _context.Posts.Add(post);

            List<PostTag> newPostTags = new List<PostTag>();

            foreach (var item in post.TagList)
            {
                newPostTags.Add(new PostTag() { PostId = createdPost.Entity.Id, TagId = item });
            }

            _context.PostTag.AddRange(newPostTags);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.SaveChanges();
        }

        public void Delete(string slug)
        {
            Post PostDelete = _context.Posts.Where(x => x.Slug == slug).FirstOrDefault();

            List<PostTag> postTags = _context.PostTag.Where(x => x.PostId == PostDelete.Id).ToList();

            _context.PostTag.RemoveRange(postTags);

            _context.Posts.Remove(PostDelete);
        }
    }
}
