using System;
using System.Collections.Generic;

namespace Supplier.Proxies.Infrastructure.proxy.HumphriesSupplier
{
    public class HumphriesSupplierProxy
    {
        public HumphriesSupplierProxy()
        {

        }

        /// <summary>
        /// depending on the overall architecture design. we might want to have a layer of validation before  mapping it. 
        /// the end point that provide data should  have done some data cleansing
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DTO.HumphriesWorkItem> GetWorkItems()
        {
            var returnlist = new List<DTO.HumphriesWorkItem>();

            foreach (var item in GetInput())
            {
                var inputArray = item.Split(',');
                if (inputArray.Length >= 4) //in actual implementation if the proxy returns list of string we need to ensure it has all 4 input
                {
                    try
                    {
                        var workitem = new DTO.HumphriesWorkItem
                        {
                            identifier = inputArray[0],
                            desc = inputArray[1],
                            unit = inputArray[2],
                            costAUD = inputArray[3],
                        };

                        returnlist.Add(workitem);
                    }
                    catch (Exception ex)
                    {
                        //TODO log error to data processor table
                    }

                }
                else
                {
                    //TODO log error to data processor table
                }

            }
            return returnlist;
        }


        /// <summary>
        /// assuming some kind of ETL process that gets this raw input
        /// assuming data are clean, validated in the ETL process
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetInput()
        {
            yield return "586e0bd4-a84c-4c39-a696-1fafdf85e5bb,Suspended Slab Formwork per m2,m2,23.59";
            yield return "e1b3e145-782b-43b3-a081-f3634a07db00,TM3 R11 Mesh,m2,83.99";
            yield return "812c8fe8-7575-474e-bd6d-0be13e72fa0a,Under Slab Pest Control (LM + Penetrations),lm,300";
            yield return "0edbbcf2-e61a-4f86-a9a7-34c94637b8cf,Under Slab Sand 100mm,m2,83.5";
            yield return "0a360e10-4e35-4e94-bd80-2e8bd6c749f1,Under Slab Sand 150mm,m2,77.24";
            yield return "45b0527b-5a8c-464c-9b93-b70629def248,Under Slab Sand 50mm,m2,66.3";
            yield return "fbc8b766-e734-4511-91ae-18b075ff19e5,N12 Reo Bar,lm,50";
            yield return "b6e3ec90-c008-4d67-b2b2-1904bef08eb6,Plastic Membrane,m2,10.5";
            yield return "94884242-19ee-444a-880d-eafccdb47fe8,Precast Concrete Pad,m2,83.996";
            yield return "7f3c48c4-f8b6-453f-b2fa-83ec31dfa85c,Bobcat to Dig LM of Strip Footing,lm,800";
        }
    }
}
