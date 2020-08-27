using Supplier.DSL.Service.Supplier.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.DSL.Service.Supplier.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierItem>> GetAllSupplierItems(decimal exchangeRate);
    }
}
