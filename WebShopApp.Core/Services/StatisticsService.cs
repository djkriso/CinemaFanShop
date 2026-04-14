using CinemaFanShop.Infrastructure.Data;
using CinemaFanShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CinemaFanShop.Core.Contracts;

namespace CinemaFanShop.Core.Services
{
    public class StatisticService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;
        private IOrderService _orderService;

        public StatisticService(ApplicationDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        public int CountClients()
        {
            return _context.Users.Count() - 1;
        }

        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        public int CountProducts()
        {
            return _context.Products.Count();
        }

        public decimal SumOrders()
        {
            decimal sum = 0;
            foreach(Order order in _orderService.GetOrders())
            {
                sum += order.TotalPrice;
            }
            return sum;
        }
    }
}
