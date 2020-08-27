using AutoMapper;
using Supplier.DSL.Service.Supplier.DTO;
using Supplier.Proxies.Infrastructure.proxy.HumphriesSupplier.Interface;
using Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier.Interface;
using System.Collections.Generic;

namespace Supplier.DSL.Service.Supplier
{
    public class SupplierService
    {
        private readonly IHumphriesSupplierProxy _humphriesSupplierProxy;
        private readonly IMegacorpSupplierProxy _megacorpSupplierProxy;
        private readonly IMapper _mapper;

        public SupplierService(IHumphriesSupplierProxy humphriesSupplierProxy, IMegacorpSupplierProxy megacorpSupplierProxy, IMapper mapper)
        {
            this._humphriesSupplierProxy = humphriesSupplierProxy;
            this._megacorpSupplierProxy = megacorpSupplierProxy;
            this._mapper = mapper;
        }

        public IEnumerable<SupplierItem> GetAllSupplierItems(decimal exchangeRate)
        {
            var megacorpSupplierItems = _megacorpSupplierProxy.GetWorkItems();
            var humphriesWorkItem = _humphriesSupplierProxy.GetWorkItems();
            var supplierItemList = new List<SupplierItem>();

            foreach (var item in megacorpSupplierItems)
            {
                var mappedItem = _mapper.Map<SupplierItem>(item, opt => opt.Items["audUsdExchangeRate"] = exchangeRate.ToString());
                supplierItemList.Add(mappedItem);
            }

            foreach (var item in humphriesWorkItem)
            {
                var mappedItem = _mapper.Map<SupplierItem>(item);
                supplierItemList.Add(mappedItem);
            }

            return supplierItemList;
        }
    }

}
