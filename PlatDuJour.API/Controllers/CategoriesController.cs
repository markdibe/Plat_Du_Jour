using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatDuJour.BO.ViewModels;
using PlatDuJour.DAL.IServices;
using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatDuJour.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //dependency injection
        private readonly IMapper _mapper;
        private readonly ICategoryRepos _category;
        public CategoriesController(IMapper mapper , ICategoryRepos category)
        {
            _mapper = mapper;
            _category = category;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryViewModel> Get([FromQuery] QueryParameters query)
        {
            var result = _category.GetAll();
            if (query.Id != default(int))
            {
                result = result.Where(x => x.CategoryId == query.Id);
            }
            if (!string.IsNullOrEmpty(query.FilterValue))
            {
                result = result.Where(x => x.CategoryName.Contains(query.FilterValue) || x.CategoryTitle.Contains(query.FilterValue));
            }

            result = result.Skip(query.PageNumber * query.Range).Take(query.Range);
            if (query.OrderByDesc) 
            {
                result = result.OrderByDescending(x=>x.CategoryId);
            }
            List<Category> categories = result.ToList();
            List<CategoryViewModel> categoriesvm = new List<CategoryViewModel>();
            foreach(var category in categories)
            {
                CategoryViewModel categoryView = _mapper.Map<CategoryViewModel>(category);
                categoriesvm.Add(categoryView);
            }
            return categoriesvm;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
