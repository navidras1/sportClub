using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class GetListOfItemsByTypeByBuffetModel
    {
        public long? ItemId { get; set; }
        public long ItemTypeId { get; set; }
        public long BuffetId{ get; set; }
    }
}
