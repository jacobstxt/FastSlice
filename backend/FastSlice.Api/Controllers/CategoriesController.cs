using Core.Interfaces;
using Core.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastSlice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await categoryService.List();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var model = await categoryService.GetItemById(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await categoryService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateModel model)
        {
            var category = await categoryService.Create(model);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateModel model)
        {
            var category = await categoryService.Update(model);

            return Ok(category);
        }

    }
}
