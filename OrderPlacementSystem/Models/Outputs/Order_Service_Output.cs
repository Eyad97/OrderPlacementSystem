using OrderPlacementSystem.Models.OrderPlacementSystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.Outputs
{
    public class Order_Service_Output
    {
        public Order_Service_Output (Order_Service order_Service)
        {
            this.service = new Service_Output(order_Service.Service);
            this.executeServiceDate = order_Service.executeServiceDate;
        }

        public Service_Output service { get; set; }
        public DateTime executeServiceDate { get; set; }
    }
}
