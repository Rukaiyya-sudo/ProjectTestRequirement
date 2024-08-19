using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMVC8CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIMVC8CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly Mvc8crudDbContext _context;

        public CategoryController(Mvc8crudDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> Get(int CategoryId)
        {
            if (CategoryId < 1)
                return BadRequest();
            var Category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == CategoryId);
            if (Category == null)
                return NotFound();
            return Ok(Category);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Category categoryData)
        {
            if (categoryData == null || categoryData.CategoryId == 0)
                return BadRequest();

            var category = await _context.Categories.FindAsync(categoryData.CategoryId);
            if (category == null)
                return NotFound();
            category.CategoryName = categoryData.CategoryName;
            //category.Description = productData.Description;
            //product.Price = productData.Price;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            if (CategoryId < 1)
                return BadRequest();
            var Category = await _context.Categories.FindAsync(CategoryId);
            if (Category == null)
                return NotFound();
            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}

