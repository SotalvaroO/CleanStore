using CleanStore.Application.Features.Sellers.Commands.CreateSellers;
using CleanStore.Application.Features.Sellers.Commands.DeleteSeller;
using CleanStore.Application.Features.Sellers.Commands.UpdateSeller;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanStore.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SellerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateSeller")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<int>> CreateSeller([FromBody] CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateSeller")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSeller([FromBody] UpdateSellerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteSeller")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSeller(int id)
        {
            var command = new DeleteSellerCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
