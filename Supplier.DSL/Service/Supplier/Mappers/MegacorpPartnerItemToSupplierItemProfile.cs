using AutoMapper;
using Supplier.DSL.Service.Supplier.DTO;
using Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier.DTO;

namespace Supplier.DSL.Service.Supplier.Mappers
{
    public class MegacorpPartnerItemToSupplierItemProfile : Profile
    {
        public MegacorpPartnerItemToSupplierItemProfile()
        {
            var map = CreateMap<MegacorpPartnerItem, SupplierItem>();

            map.ForMember(d => d.SupplierId, opt => opt.MapFrom(src => src.Id));
            map.ForMember(d => d.ItemName, opt => opt.MapFrom(src => src.Description));
            map.ForMember(d => d.Price, opt => opt.MapFrom<UsdCentsToAudDollarResolver>());
        }
    }
}
