using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPlacementSystem.Models.Inputs;
using OrderPlacementSystem.Models.Outputs;
using OrderPlacementSystem.Helpers;

namespace OrderPlacementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderHelper _orderHelper;

        public OrderController() => _orderHelper = new OrderHelper();

        [HttpPost("AddOrder")]
        public ResultOutput AddOrder([FromBody] Order_Input order_Input)
        {
           return _orderHelper.AddOrder(order_Input);
        }

        [HttpPut("EditOrder")]
        public ResultOutput EditOrder(int id,[FromBody] Order_Input order_Input)
        {
            return _orderHelper.EditOrder(id, order_Input);
        }

        [HttpDelete("DeleteOrder")]
        public ResultOutput DeleteOrder(int id)
        {
            return _orderHelper.DeleteOrder(id);
        }

        [HttpGet("GetOrderById")]
        public ResultOutput GetOrderById(int id)
        {
            return _orderHelper.GetOrderById(id);
        }

        [HttpGet("GetAllOrdersOrByPhone")]
        public ResultOutput GetAllOrdersOrByPhone(string phone)
        {
            return _orderHelper.GetAllOrdersOrByPhone(phone);
        }
    }
}
