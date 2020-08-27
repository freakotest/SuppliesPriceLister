using System.Collections.Generic;

namespace Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier.DTO
{
    public class MegacorpPartnerDetail
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }
        public IEnumerable<MegacorpPartnerItem> Supplies { get; set; }
    }
}
