using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderPlacementSystem.Models.OrderPlacementSystemDB;
using OrderPlacementSystem.Models.Inputs;
using OrderPlacementSystem.Models.Outputs;

namespace OrderPlacementSystem.Helpers
{
    public class OrderHelper
    {
        private OrderPlacementSystemContext _context;

        public OrderHelper() => _context = new OrderPlacementSystemContext();

        public ResultOutput AddOrder(Order_Input order_Input)
        {
            try
            {
                int orderId = 0;

                if (order_Input.services.Count == 0)
                    return new ResultOutput(ResponseCode.NotFound, "Services not Found");

                var executionStrategy = _context.Database.CreateExecutionStrategy();
                executionStrategy.Execute(() =>
                {
                    var trans = _context.Database.BeginTransaction();
                    Orders order = new Orders
                    {
                        name = order_Input.name.Trim(),
                        phoneNumber = order_Input.phoneNumber.Trim(),
                        email = order_Input.email.Trim(),
                        addressFrom = order_Input.addressFrom.Trim(),
                        addressTo = order_Input.addressTo.Trim(),
                        notes = order_Input.notes.Trim(),
                        creationDate = DateTime.Now,
                        updatedDate = DateTime.Now
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    orderId = order.id;

                    if (order_Input.services != null)
                    {
                        foreach (var ordSer in order_Input.services)
                        {
                            Order_Service order_Service = new Order_Service
                            {
                                orderId = orderId,
                                serviceId = ordSer.serviceId,
                                executeServiceDate = ordSer.executeServiceDate,
                                creationDate = DateTime.Now,
                                updatedDate = DateTime.Now
                            };
                            _context.Order_Service.Add(order_Service);
                            _context.SaveChanges();
                        }
                    }
                    trans.Commit();
                });
                return GetOrderById(orderId);
            }
            catch (Exception ex)
            {
                return new ResultOutput(ResponseCode.Error, ex.ToString());
            }
        }

        public ResultOutput EditOrder(int id, Order_Input order_Input)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                    return new ResultOutput(ResponseCode.NotFound, "Order not Found");

                if (order_Input.services.Count == 0)
                    return new ResultOutput(ResponseCode.BadRequest, "Services not Found");

                var executionStrategy = _context.Database.CreateExecutionStrategy();
                executionStrategy.Execute(() =>
                {
                    var trans = _context.Database.BeginTransaction();
                    order.name = order_Input.name.Trim();
                    order.phoneNumber = order_Input.phoneNumber.Trim();
                    order.email = order_Input.email.Trim();
                    order.addressFrom = order_Input.addressFrom.Trim();
                    order.addressTo = order_Input.addressTo.Trim();
                    order.notes = order_Input.notes.Trim();
                    order.updatedDate = DateTime.Now;
                    _context.Entry(order).State = EntityState.Modified;
                    _context.SaveChanges();

                    if (order_Input.services != null)
                    {
                        List<int> OrdSerIds = new List<int>();
                        foreach (var order_Service in order_Input.services)
                        {
                            var ordSer = _context.Order_Service.FirstOrDefault(o => o.orderId == id && o.serviceId == order_Service.serviceId);
                            if (ordSer != null)
                            {
                                OrdSerIds.Add(ordSer.id);
                                ordSer.executeServiceDate = order_Service.executeServiceDate;
                                ordSer.updatedDate = DateTime.Now;
                                _context.Entry(ordSer).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            else
                            {
                                Order_Service ordService = new Order_Service
                                {
                                    orderId = id,
                                    serviceId = order_Service.serviceId,
                                    executeServiceDate = order_Service.executeServiceDate,
                                    creationDate = DateTime.Now,
                                    updatedDate = DateTime.Now
                                };
                                _context.Order_Service.Add(ordService);
                                _context.SaveChanges();
                                OrdSerIds.Add(ordService.id);
                            }
                        }
                        if (OrdSerIds.Count > 0)
                        {
                            var order_Services = _context.Order_Service.Where(p => !OrdSerIds.Contains(p.id) && p.orderId == id).ToList();
                            if (order_Services != null)
                            {
                                foreach (var item in order_Services)
                                {
                                    _context.Order_Service.Remove(item);
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    trans.Commit();
                });
                return GetOrderById(id);
            }
            catch (Exception ex)
            {
                return new ResultOutput(ResponseCode.Error, ex.ToString());
            }
        }

        public ResultOutput DeleteOrder(int id)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                    return new ResultOutput(ResponseCode.NotFound, "Order not Found");

                var order_Services = _context.Order_Service.Where(o => o.orderId == id).ToList();
                if (order_Services != null)
                {
                    foreach (var item in order_Services)
                    {
                        _context.Order_Service.Remove(item);
                    }
                    _context.SaveChanges();
                }
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return new ResultOutput(ResponseCode.Ok, "Order Deleted Successfully");
            }
            catch (Exception ex)
            {
                return new ResultOutput(ResponseCode.Error, ex.ToString());
            }
        }

        public ResultOutput GetOrderById(int id)
        {
            try
            {
                var order = _context.Orders.Include(o => o.Order_Services).ThenInclude(s => s.Service)
                                           .Where(o => o.id == id)
                                           .FirstOrDefault();
                if (order == null)
                    return new ResultOutput(ResponseCode.BadRequest, "Order not Found");
                return new ResultOutput(ResponseCode.Ok, new Order_Output(order));
            }
            catch (Exception ex)
            {
                return new ResultOutput(ResponseCode.Error, ex.ToString());
            }
        }

        public ResultOutput GetAllOrdersOrByPhone(string phone)
        {
            try
            {
                List<Order_Output> orders = new List<Order_Output>();
                    orders = _context.Orders.Include(o => o.Order_Services).ThenInclude(s => s.Service)
                                            .Where(o => !string.IsNullOrEmpty(phone) ? o.phoneNumber == phone.Trim() : true)
                                            .Select(o => new Order_Output(o))
                                            .ToList();
                return new ResultOutput(ResponseCode.Ok, orders);
            }
            catch (Exception ex)
            {
                return new ResultOutput(ResponseCode.Error, ex.ToString());
            }
        }
    }
}
