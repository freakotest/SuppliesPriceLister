using Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier.DTO;
using System.Collections.Generic;

namespace Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier.Interface
{
    public interface IMegacorpSupplierProxy
    {
        IEnumerable<MegacorpPartnerItem> GetWorkItems();
    }
}
