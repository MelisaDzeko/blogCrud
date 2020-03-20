using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogCRUD.Context;
using blogCRUD.DTOs;
using blogCRUD.Interfaces;
using blogCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static blogCRUD.DTOs.BlogPostInsertDTO;
using static blogCRUD.DTOs.BlogPostUpdateDTO;

namespace blogCRUD.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public MultipleBlogsDTO GetAll(string tag = "")
        {
            List<BlogPostDTO> postDTOs = new List<BlogPostDTO>();
            MultipleBlogsDTO mulitpleBlogs = new MultipleBlogsDTO();

            if (tag == "")
            {
                var list = _unitOfWork.Post.GetAll();
                foreach (var item in list)
                {
                    postDTOs.Add(new BlogPostDTO
                    {
                        slug = item.Slug,
                        createdAt = item.CreatedAt,
                        updatedAt = item.UpdatedAt,
                        body = item.Body,
                        description = item.Description,
                        tagList = item.TagList,
                        title = item.Title
                    });
                }
                mulitpleBlogs.blogPosts = postDTOs;
                mulitpleBlogs.postsCount = postDTOs.Count();
            }

            else
            {
                var list = _unitOfWork.Post.Search(tag);
                foreach (var item in list)
                {
                    postDTOs.Add(new BlogPostDTO
                    {
                        slug = item.Slug,
                        createdAt = item.CreatedAt,
                        updatedAt = item.UpdatedAt,
                        body = item.Body,
                        description = item.Description,
                        tagList = item.TagList,
                        title = item.Title
                    });
                }
                mulitpleBlogs.blogPosts = postDTOs;
                mulitpleBlogs.postsCount = postDTOs.Count();
            }
            return mulitpleBlogs;
        }

        [HttpGet("{slug}")]
        public SingleBlogDTO GetPost(string slug)
        {
            SingleBlogDTO singleBlog = new SingleBlogDTO();
            Post post = _unitOfWork.Post.GetPost(slug);
            BlogPostDTO postDTO = new BlogPostDTO()
            {
                slug = post.Slug,
                title = post.Title,
                body = post.Body,
                description = post.Description,
                createdAt = post.CreatedAt,
                updatedAt = post.UpdatedAt,
                tagList = post.TagList
            };

            singleBlog.blogPost = postDTO;

            return singleBlog;
        }

        [HttpPost]
        public ActionResult Insert(BlogPostInsert post)
        {
            Post newPost = new Post()
            {
                Title = post.blogPost.title,
                Description = post.blogPost.description,
                Body = post.blogPost.body,
                TagList = post.blogPost.tagList,
                CreatedAt = DateTime.Now,
                Slug = post.blogPost.title.Replace(" ", "-").ToLower()
            };

            _unitOfWork.Post.Insert(newPost);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut("{slug}")]
        public void Update(string slug, BlogPostUpdateDTO post)
        {
            Post changePost = _unitOfWork.Post.GetPost(slug);
            changePost.Title = post.blogPost.title;
            changePost.Slug = post.blogPost.title.Replace(" ", "-").ToLower();
            changePost.UpdatedAt = DateTime.Now;
            _unitOfWork.Post.Update(changePost);
        }

        [HttpDelete("{slug}")]
        public void Delete(string slug)
        {
            _unitOfWork.Post.Delete(slug);
            _unitOfWork.Save();
        }
    }

}