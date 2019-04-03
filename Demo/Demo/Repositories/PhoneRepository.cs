using Demo.Interfaces;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private ShopDbContext context;
        public PhoneRepository(ShopDbContext context)
        {
            this.context = context;
        }
        public void Create(Phone item)
        {
            context.Phones.Add(item); ;
        }

        public void Delete(int id)
        {
            Phone phone = context.Phones.Find(id);
            context.Phones.Remove(phone);
        }

        public Phone GetById(int id)
        {
            return context.Phones.Find(id);
        }

        public IEnumerable<Phone> GetList()
        {
           return context.Phones.ToList();
        }

        public void Update(Phone item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
