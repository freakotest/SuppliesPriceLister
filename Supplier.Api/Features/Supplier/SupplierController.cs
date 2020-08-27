using MediatR;
using Microsoft.AspNetCore.Mvc;
using Supplier.Api.Features.Supplier.Request;
using Supplier.Api.Infrastructure;
using System.Threading.Tasks;

namespace Supplier.Api.Features.Supplier
{
    [ApiController]
    public class SupplierController
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/supplier/workitem/list")]
        public async Task<IActionResult> GetAllWorkItems() => (await _mediator.Send(new GetAllWorkItemRequest())).ToActionResult();
    }
}
