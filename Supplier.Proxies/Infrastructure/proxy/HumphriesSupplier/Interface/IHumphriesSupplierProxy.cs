using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Proxies.Infrastructure.proxy.HumphriesSupplier.Interface
{
    public interface IHumphriesSupplierProxy
    {
        IEnumerable<DTO.HumphriesWorkItem> GetWorkItems();
    }
}
