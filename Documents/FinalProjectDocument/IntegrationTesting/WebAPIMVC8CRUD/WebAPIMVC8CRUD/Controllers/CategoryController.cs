using Microsoft.AspNetCore.Mvc;
using WebAPIMVC8CRUD.Services;
using WebAPIMVC8CRUD.Model;
using WebAPIMVC8CRUD.Services;

namespace WebAPIMVC8CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var emps = _service.GetAll();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var emp = _service.GetByCategoryId(id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Category emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEmp = _service.Add(emp);
            return CreatedAtAction("Get", newEmp);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_service.Delete(id))
                return Ok("The Category is deleted.");
            else
                return NotFound("The Category not found.");
        }
    }
}