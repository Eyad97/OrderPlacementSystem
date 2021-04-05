using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.Inputs
{
    public class Order_Service_Input
    {
        public int serviceId { get; set; }

        public DateTime executeServiceDate { get; set; }
    }
}
