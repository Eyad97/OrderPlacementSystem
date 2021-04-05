using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.OrderPlacementSystemDB
{
    public class Order_Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Orders Order { get; set; }
        public int orderId { get; set; }
        public virtual Services Service { get; set; }
        public int serviceId { get; set; }
        public DateTime executeServiceDate { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updatedDate { get; set; }
    }
}
