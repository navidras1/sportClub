using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models
{
    public class AddBuffetItemModel
    {
        [Required(ErrorMessage = "please insert buffet id")]
        public long? BuffetId { get; set; }

       public  List<BuffetItems> items { get; set; }
        
        
    }

    public class BuffetItems
    {
        [Required(ErrorMessage = "please insert buffet item id")]
        public long? BuffetItem { get; set; }


        [Required(ErrorMessage = "please insert price")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "please insert buffet item quantity")]
        public int? Quantity { get; set; }
    }

}
