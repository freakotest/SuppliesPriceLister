using Supplier.DSL.Service.Supplier.DTO;
using System.Collections.Generic;

namespace Supplier.Api.Features.Supplier.OutputModel
{
    public class GetAllWorkItemOutputModel
    {
        public IEnumerable<SupplierItem> SupplierItemList { get; set; }
    }
}
