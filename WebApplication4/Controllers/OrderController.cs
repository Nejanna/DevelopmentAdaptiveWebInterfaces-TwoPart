using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        
            private readonly IOrderService _orderService;

            public OrderController(IOrderService orderService)
            {
                _orderService = orderService;
            }

            [HttpGet]
            public async Task<IActionResult> GetOrders()
            {
                var orders = await _orderService.GetOrders();
                return Ok(orders);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetOrder(int id)
            {
                var order = await _orderService.GetOrder(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
        
            [HttpPost]
            public async Task<IActionResult> CreateOrder(Order order)
            {
                if (order == null)
                {
                    return BadRequest("Invalid order data.");
                }

                try
                {
                    var orderId = await _orderService.CreateOrder(order);
                    return CreatedAtAction(nameof(GetOrder), new { id = orderId }, order);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateOrder(int id, Order order)
            {
                if (id != order.Id)
                {
                    return BadRequest("Mismatched id parameter.");
                }

                try
                {
                    await _orderService.UpdateOrder(order);
                    return NoContent();
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOrder(int id)
            {
                try
                {
                    await _orderService.DeleteOrder(id);
                    return NoContent();
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }
            }
        }
    }


