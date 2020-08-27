using MediatR;
using Microsoft.Extensions.Options;
using Supplier.Api.Features.Supplier.OutputModel;
using Supplier.Api.Features.Supplier.Request;
using Supplier.Api.Infrastructure;
using Supplier.Api.Shared.OutputModel;
using Supplier.DSL.Service.Supplier.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Supplier.Api.Features.Supplier.RequestHandler
{
    public class GetAllWorkItemRequestHandler : IRequestHandler<GetAllWorkItemRequest, ApiResponse<GetAllWorkItemOutputModel>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IOptions<AppSettingsModel> _appsettings;

        public GetAllWorkItemRequestHandler(ISupplierService supplierService, IOptions<AppSettingsModel> appsettings)
        {
            _supplierService = supplierService;
            _appsettings = appsettings;
        }

        public async Task<ApiResponse<GetAllWorkItemOutputModel>> Handle(GetAllWorkItemRequest request, CancellationToken cancellationToken)
        {
            decimal.TryParse(_appsettings.Value.audUsdExchangeRate, out decimal exchangeRate);

            var supplierItemList = await _supplierService.GetAllSupplierItems(exchangeRate);

            var output = new GetAllWorkItemOutputModel
            {
                SupplierItemList = supplierItemList
            };

            return new ApiResponse<GetAllWorkItemOutputModel>(output);
        }

    }
}
