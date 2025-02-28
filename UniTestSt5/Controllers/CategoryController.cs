using Microsoft.AspNetCore.Mvc;
using UniTestSt5.Models;
using UniTestSt5.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniTestSt5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
    
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Category>> Get()
            => await _service.GetCategories();

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Category?> Get(Guid id)
            => await _service.GetCategory(id);

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Save(category);
                if(result == "Ok")
                {
                    return Created("",category);
                }
                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Update(id, category);
                if (result == "Ok")
                {
                    return Ok();
                }
                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            if (result == "Ok")
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
