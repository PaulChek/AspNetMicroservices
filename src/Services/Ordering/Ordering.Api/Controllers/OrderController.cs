using Application.Features.Orders;
using Application.Features.Orders.Commands;
using Application.Features.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly IMediator _mediatr;

        public OrderController(IMediator mediatr) {
            _mediatr = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetAsync(string id) {
            var res = await _mediatr.Send(new GetOrders.Query(id));
            return Ok(res.OrdersVm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id) {
            await _mediatr.Send(new Delete.Command(id));
            return NoContent();
        }
    }
}
