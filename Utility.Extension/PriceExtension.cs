namespace Utility.Extension
{
    public static class PriceExtension
    {
        public static decimal UsdCentsToAUD(this string PriceInUsdCents, decimal rate)
        {
            int.TryParse(PriceInUsdCents, out int priceInUsdCents);
            var priceInAud = (priceInUsdCents / 100) / rate;

            return decimal.Round(priceInAud, 2);
        }
    }
}
