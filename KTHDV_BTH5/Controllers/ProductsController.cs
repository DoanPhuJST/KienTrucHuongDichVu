using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KTHDV_BTH5.Models;

namespace KTHDV_BTH5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<ProductReport> products = new List<ProductReport>
    {
        new ProductReport { Id = 1, Name = "Product A", Quantity = 100, UnitPrice = 50, Cost = 30 },
        new ProductReport { Id = 2, Name = "Product B", Quantity = 200, UnitPrice = 30, Cost = 20 }
    };

        [HttpGet]
        public IActionResult GetAll() => Ok(products);

        [HttpPut("{id}")]
        public IActionResult UpdateQuantity(int id, [FromBody] ProductUpdateRequest request)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound("Product not found");

            product.Quantity = request.Quantity;
            return Ok(product);
        }
    }
}
