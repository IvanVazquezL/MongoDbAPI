using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;

namespace MongoDbAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            
            if (product.Name == string.Empty) {
                ModelState.AddModelError("Name", "Name is required");
            }

            await db.InsertProduct(product);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null)
                return BadRequest();

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "Name is required");
            }

            product.Id = new ObjectId(id);
            await db.UpdateProduct(product);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);
            return NoContent();
        }
    }
}
