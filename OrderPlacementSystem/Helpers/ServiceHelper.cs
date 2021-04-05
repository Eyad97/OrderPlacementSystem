using OrderPlacementSystem.Models.OrderPlacementSystemDB;
using OrderPlacementSystem.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Helpers
{
    public class ServiceHelper
    {
        private OrderPlacementSystemContext _context;

        public ServiceHelper() => _context = new OrderPlacementSystemContext();

        public ResultOutput GetAllServices()
        {
            try
            {
                var service = _context.Services.Select(s => new Service_Output(s)).ToList();
                return new ResultOutput(ResponseCode.Ok, service);
            }
            catch(Exception ex)
            {
                return new ResultOutput(ResponseCode.Error, ex.ToString());
            }
        }
    }
}
