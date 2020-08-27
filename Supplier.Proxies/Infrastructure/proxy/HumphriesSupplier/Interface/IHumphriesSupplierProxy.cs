using System.Collections.Generic;

namespace Supplier.Proxies.Infrastructure.proxy.HumphriesSupplier.Interface
{
    public interface IHumphriesSupplierProxy
    {
        IEnumerable<DTO.HumphriesWorkItem> GetWorkItems();
    }
}
