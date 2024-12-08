using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KTHDV_BTH5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static List<OrderReport> orders = new List<OrderReport>();

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderRequest request)
        {
            var newOrder = new Order
            {
                Id = orders.Count + 1,
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                Status = "pending"
            };
            orders.Add(newOrder);
            return Created($"/orders/{newOrder.Id}", newOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] OrderStatusRequest request)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound("Order not found");

            order.Status = request.Status;
            return Ok(order);
        }
    }
}
