using AutoMapper;
using Supplier.DSL.Service.Supplier.DTO;
using Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier.DTO;
using Utility.Extension;

namespace Supplier.DSL.Service.Supplier.Mappers
{
    public class UsdCentsToAudDollarResolver : IValueResolver<MegacorpPartnerItem, SupplierItem, string>
    {
        public string Resolve(MegacorpPartnerItem source, SupplierItem destination, string destMember, ResolutionContext context)
        {
            var audUsdExchangeRate = context.Items["audUsdExchangeRate"] as string;//TODO check if it supports decimal type
            if (string.IsNullOrWhiteSpace(audUsdExchangeRate)) audUsdExchangeRate = "1";
            decimal.TryParse(audUsdExchangeRate, out decimal exchangerate);

            var pricenInAudDollar = source.PriceInCents.UsdCentsToAUD(exchangerate);
            return decimal.Round(pricenInAudDollar, 2).ToString();
        }
    }
}
