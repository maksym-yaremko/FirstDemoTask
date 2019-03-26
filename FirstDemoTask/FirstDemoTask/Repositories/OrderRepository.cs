using FirstDemoTask.Interfaces;
using FirstDemoTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoTask.Repositories
{
    public class OrderRepository:IRepository<Order>
    {
        private MobileContext _db;

        public OrderRepository(MobileContext db)
        {
            _db = db;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Include(o=>o.Phone);
        }

        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }
    }
}
