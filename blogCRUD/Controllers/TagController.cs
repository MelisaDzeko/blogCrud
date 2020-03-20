using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogCRUD.DTOs;
using blogCRUD.Interfaces;
using blogCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blogCRUD.Controllers
{
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/tags")]
        public TagsDTO GetAll()
        {
            var tagGetAll = _unitOfWork.Tag.GetAll();

            TagsDTO tagList = new TagsDTO()
            {
                tags = new List<string>()
            };

            tagList.tags = tagGetAll.Select(x => x.TagId).ToList();

            return tagList;
        }
    }
}