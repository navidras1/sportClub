using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class PurchaseItemModel
    {
        public List<IdQuantity> IdQuantities { get; set; }
        public long UserId { get; set; }

    }

    public class IdQuantity
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
    }
}
