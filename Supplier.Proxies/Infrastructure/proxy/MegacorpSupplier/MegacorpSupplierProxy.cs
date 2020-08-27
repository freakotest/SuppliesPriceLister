﻿using Newtonsoft.Json;
using System;

namespace Supplier.Proxies.Infrastructure.proxy.MegacorpSupplier
{
    public class MegacorpSupplierProxy
    {
        private readonly ILogger<MegacorpSupplierProxy> _logger;

        public MegacorpSupplierProxy()
        {

        }

        public DTO.MegacorpPartnerDTO GetWorkItems()
        {
            try
            {

            }
            catch(Exception ex)
            {
                var input = GetInput();

                return JsonConvert.DeserializeObject<DTO.MegacorpPartnerDTO>(input);
            }

        }

/// <summary>
/// 
/// </summary>
/// <returns></returns>
        private string GetInput()
        {
            return @"{
  'partners': [
    {
      'name': 'Megacorp Southeast',
      'partnerType': 'INTERNAL',
      'partnerAddress': '14 Park Crescent, Clayton',
      'supplies': [
        {
          'id': 1,
          'description': '100 x 200 x 20mpa Internal Beam',
          'uom': 'lm',
          'priceInCents': 4000,
          'providerId': '907d853f-dbe7-45c0-8e59-9dff4044cf80',
          'materialType': 'Steel'
        },
        {
          'id': 0,
          'description': '100 x 350 Thickened Edge',
          'uom': 'lm',
          'priceInCents': 3500,
          'providerId': 'b77b9733-8cb4-436f-9e2c-b61ad1b3a42f',
          'materialType': 'Steel'
        },
        {
          'id': 2,
          'description': '1000 x 1000 x 350 x 20mpa Square Pad Footing',
          'uom': 'lm',
          'priceInCents': 1225,
          'providerId': 'b50f3453-89cb-4388-81ac-6c8a1619d3ef',
          'materialType': 'Lumber'
        },
        {
          'id': 3,
          'description': '100mm x 25mpa Slab',
          'uom': 'm2',
          'priceInCents': 20235,
          'providerId': '907d853f-dbe7-45c0-8e59-9dff4044cf80',
          'materialType': 'Concrete'
        },
        {
          'id': 4,
          'description': '100mm x 32 mpa Slab',
          'uom': 'lm',
          'priceInCents': 2250,
          'providerId': 'b50f3453-89cb-4388-81ac-6c8a1619d3ef',
          'materialType': 'Concrete'
        },
        {
          'id': 6,
          'description': '100 x 200 x 20mpa Internal Beam',
          'uom': 'lm',
          'priceInCents': 200,
          'providerId': '907d853f-dbe7-45c0-8e59-9dff4044cf80',
          'materialType': 'Steel'
        },
        {
          'id': 7,
          'description': '11 x 200 Trench Mesh',
          'uom': 'ea',
          'priceInCents': 1496,
          'providerId': 'b50f3453-89cb-4388-81ac-6c8a1619d3ef',
          'materialType': 'Steel'
        }
      ]
    },
    {
      'name': 'Megacorp Northwest',
      'partnerType': 'INTERNAL',
      'partnerAddress': '235 Kelvindale Drive, North Melbourne, VIC 3175',
      'supplies': [
        {
          'id': 10,
          'description': '600 x 150 Concrete Gutter Crossover',
          'uom': 'm2',
          'priceInCents': 8000,
          'providerId': '907d853f-dbe7-45c0-8e59-9dff4044cf80',
          'materialType': 'Steel'
        },
        {
          'id': 11,
          'description': '75mm x 20mpa Slab',
          'uom': 'm2',
          'priceInCents': 7500,
          'providerId': 'b77b9733-8cb4-436f-9e2c-b61ad1b3a42f',
          'materialType': 'Concrete'
        },
        {
          'id': 12,
          'description': '8 x 200 Trench Mesh',
          'uom': 'm2',
          'priceInCents': 8225,
          'providerId': 'b50f3453-89cb-4388-81ac-6c8a1619d3ef',
          'materialType': 'Steel'
        },
        {
          'id': 13,
          'description': 'Backhoe to Dig LM of Pier Hole',
          'uom': 'lm',
          'priceInCents': 14235,
          'providerId': '907d853f-dbe7-45c0-8e59-9dff4044cf80',
          'materialType': null
        },
        {
          'id': 14,
          'description': 'Bobcat to Dig LM of Strip Footing',
          'uom': 'lm',
          'priceInCents': 950,
          'providerId': 'b50f3453-89cb-4388-81ac-6c8a1619d3ef',
          'materialType': null
        },
        {
          'id': 16,
          'description': 'Bobcat with Auger to Dig LM of Pier Hole',
          'uom': 'lm',
          'priceInCents': 700,
          'providerId': '907d853f-dbe7-45c0-8e59-9dff4044cf80',
          'materialType': null
        },
        {
          'id': 17,
          'description': '11 x 200 Trench Mesh',
          'uom': 'm2',
          'priceInCents': 1496,
          'providerId': 'b50f3453-89cb-4388-81ac-6c8a1619d3ef',
          'materialType': 'Steel'
        }
      ]
    }
  ]
}";
        }
    }


}
