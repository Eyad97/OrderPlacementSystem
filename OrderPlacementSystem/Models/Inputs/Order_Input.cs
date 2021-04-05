using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.Inputs
{
    public class Order_Input
    {
        [Required(AllowEmptyStrings =false)]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string phoneNumber { get; set; }

        public string email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string addressFrom { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string addressTo { get; set; }

        [Required]
        public List<Order_Service_Input> services { get; set; } 

        public string notes { get; set; }
    }
}
