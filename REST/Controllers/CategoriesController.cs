using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly Repository _repository;

        public CategoriesController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<CategoryDTO>> ListCategories() => _repository
            .GetCategories(c => CategoryDTO.FromCategory(c));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repository.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(CategoryDTO.FromCategory(category));
        }
    }

    public class CategoryDTO
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }

        public static CategoryDTO FromCategory(Category category) => new CategoryDTO
        {
            ID = category.CategoryId,
            Name = category.Name,
            LastUpdated = category.LastUpdate,
        };
    }
}