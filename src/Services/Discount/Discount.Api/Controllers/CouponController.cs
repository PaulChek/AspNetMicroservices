using Discount.Api.Model;
using Discount.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CouponController : ControllerBase {
        private readonly IRepository _repo;

        public CouponController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet("{productName}")]
        public async Task<ActionResult<Coupon>> Get(string productName) {
            return Ok(await _repo.Get(productName));
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Put(Coupon coupon) {
            return Ok(await _repo.Create(coupon));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string productName) {
            return Ok(await _repo.Delete(productName));
        }
    }
}
