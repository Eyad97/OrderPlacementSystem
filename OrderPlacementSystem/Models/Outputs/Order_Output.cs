using OrderPlacementSystem.Models.OrderPlacementSystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.Outputs
{
    public class Order_Output
    {
        public Order_Output (Orders order)
        {
            this.id = order.id;
            this.name = order.name;
            this.phoneNumber = order.phoneNumber;
            this.email = order.email;
            this.addressFrom = order.addressFrom;
            this.addressTo = order.addressTo;
            if (order.Order_Services != null)
            {
                List<Order_Service_Output> order_Services = new List<Order_Service_Output>(); 
                foreach (var serOrd in order.Order_Services)
                {
                    order_Services.Add(new Order_Service_Output(serOrd));
                }
                this.services = order_Services;
            }
            this.notes = order.notes;
            this.creationDate = order.creationDate;
            this.updatedDate = order.updatedDate;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string addressFrom { get; set; }
        public string addressTo { get; set; }
        public List<Order_Service_Output> services { get; set; }
        public string notes { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updatedDate { get; set; }
    }
}
