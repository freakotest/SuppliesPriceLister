using MediatR;
using Supplier.Api.Features.Supplier.OutputModel;
using Supplier.Api.Shared.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Api.Features.Supplier.Request
{
    public class GetAllWorkItemRequest : IRequest<ApiResponse<GetAllWorkItemOutputModel>>
    {
    }
}
