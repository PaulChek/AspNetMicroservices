using Catalog.Api.Model;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IRepository<Product> _repo;

        public ProductController(IRepository<Product> repo) {
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<Product>> Get() {
            return await _repo.GetAllAsync();
        }
        [HttpGet("{id:length(24)}", Name = "GetOne")]
        public async Task<ActionResult<Product>> Get(string id) {
            return Ok(await _repo.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Pos(Product p) {

            await _repo.AddAsync(p);

            return CreatedAtRoute("GetOne", new { id = p.Id }, p);
        }

    }
}
