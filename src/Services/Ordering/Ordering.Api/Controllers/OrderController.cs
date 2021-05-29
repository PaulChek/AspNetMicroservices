using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.App.Features.Queries;
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
        public async Task<IReadOnlyList<Domain.Model.Order>> GetAsync(string userId) {
           var resp = await _mediator.Send(new GetOrdersList.Query(userId));
            return resp.orders;
        }
    }
}
