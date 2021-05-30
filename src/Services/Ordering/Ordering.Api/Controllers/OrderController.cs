using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.App.Features.Commands;
using Ordering.App.Features.Queries;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IReadOnlyList<Domain.Model.Order>>> GetAsync(string userId) {
            var resp = await _mediator.Send(new GetOrdersList.Query(userId));
            return Ok(resp.orders);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostCheckOutAsync([FromBody] Order order) {
            var res = await _mediator.Send(new CheckOut.Command(order));
            return Ok(res.res);
        }
        [HttpDelete]
        public async Task<NoContentResult> DeleteAsync(int id) {
            var res = await _mediator.Send(new DeleteOrder.Command(id));
            return NoContent();
        }
    }
}
