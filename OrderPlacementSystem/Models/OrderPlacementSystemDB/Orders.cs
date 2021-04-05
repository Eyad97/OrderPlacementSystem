using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.OrderPlacementSystemDB
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string addressFrom { get; set; }
        public string addressTo { get; set; }
        public string notes { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual ICollection<Order_Service> Order_Services { get; set; } = new HashSet<Order_Service>();
    }
}
