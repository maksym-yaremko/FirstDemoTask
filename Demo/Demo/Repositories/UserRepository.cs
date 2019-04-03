using Demo.Interfaces;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ShopDbContext context;
        public UserRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public void Create(User item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetList()
        {
            return context.Users.ToList();
        }

        public void Update(User item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
