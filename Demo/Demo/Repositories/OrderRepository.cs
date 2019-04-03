using Demo.Interfaces;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private ShopDbContext context;
        public OrderRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public void Create(Order item)
        {
            context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = context.Orders.Find(id);
            context.Orders.Remove(order);
        }

        public Order GetById(int id)
        {
            return context.Orders.Include(o => o.User).Include(o => o.Phone).FirstOrDefault(o=>o.Id==id);
        }

        public IEnumerable<Order> GetList()
        {
            return context.Orders.Include(o => o.Phone).Include(o => o.User).ToList();
        }

        public void Update(Order item)
        {
            context.Update(item);
            context.Entry(item).Property(x => x.Date).IsModified = false;  
        }
    }
}
