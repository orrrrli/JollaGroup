using Business.Contracts;
using Business.Implementation;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {

            _categoryService = categoryService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Category category)
        {
            if (category == null) return BadRequest("Request is null");
            int id = _categoryService.Add(category);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _categoryService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Category category = _categoryService.Get(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Category category)
        {
            if (category == null) return BadRequest("Request is null");
            category.Id = id;
            bool updated = _categoryService.Update(category);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(category);
        }

    }
}


