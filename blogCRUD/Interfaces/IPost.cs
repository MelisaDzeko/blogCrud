using blogCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogCRUD.Interfaces
{
    public interface IPost
    {
        List<Post> GetAll();

        Post GetPost(string slug);

        List<Post> Search(string tag);

        void Insert(Post post);

        void Update(Post post);

        void Delete(string slug);
    }
}
