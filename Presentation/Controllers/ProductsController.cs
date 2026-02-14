using Application.Features.Product.Command;
using Application.Features.Product.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllProductQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createProduct, cancellationToken);

            return Ok(result);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProduct, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(updateProduct, cancellationToken);

            return Ok(result);
        }
        [HttpDelete("delete-product/{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = Id} , cancellationToken);

            return Ok(result);
        }

        [HttpGet("get-product/{Id}")]
        public async Task<IActionResult> GetProductById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductByIDQuery { Id = Id }, cancellationToken);

            return Ok(result);
        }
    }
}
