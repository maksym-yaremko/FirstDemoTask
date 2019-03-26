using FirstDemoTask.Interfaces;
using FirstDemoTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoTask.Repositories
{
    public class PhoneRepository:IRepository<Phone>
    {
        private MobileContext db;

        public PhoneRepository(MobileContext context)
        {
            this.db = context;
        }

        public IEnumerable<Phone> GetAll()
        {
            return db.Phones;
        }

        public Phone Get(int id)
        {
            return db.Phones.Find(id);
        }

        public void Create(Phone phone)
        {
            db.Phones.Add(phone);
        }

        public void Update(Phone phone)
        {
            db.Entry(phone).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Phone phone = db.Phones.Find(id);
            if (phone != null)
                db.Phones.Remove(phone);
        }
    }
}
