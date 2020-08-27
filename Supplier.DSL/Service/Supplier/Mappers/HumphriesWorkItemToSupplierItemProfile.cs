using AutoMapper;
using Supplier.DSL.Service.Supplier.DTO;
using Supplier.Proxies.Infrastructure.proxy.HumphriesSupplier.DTO;

namespace Supplier.DSL.Service.Supplier.Mappers
{
    public class HumphriesWorkItemToSupplierItemProfile : Profile
    {
        public HumphriesWorkItemToSupplierItemProfile()
        {
            var map = CreateMap<HumphriesWorkItem, SupplierItem>();

            map.ForMember(d => d.SupplierId, opt => opt.MapFrom(src => src.identifier));
            map.ForMember(d => d.ItemName, opt => opt.MapFrom(src => src.desc));
            map.ForMember(d => d.Price, opt => opt.MapFrom(src => src.costAUD));
        }
    }
}
