using CleanStore.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanStore.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}",Name = "GetProduct")]
        [ProducesResponseType(typeof(IEnumerable<ProductsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductsVm>>> GetProductsByUsername(string username)
        {
            var query = new GetProductsQuery(username);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
