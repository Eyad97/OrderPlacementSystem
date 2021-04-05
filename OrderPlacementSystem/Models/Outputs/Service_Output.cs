using OrderPlacementSystem.Models.OrderPlacementSystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.Outputs
{
    public class Service_Output
    {
        public Service_Output (Services service)
        {
            this.id = service.id;
            this.name = service.name;
        }

        public int id { get; set; }
        public string name { get; set; }
    }
}
