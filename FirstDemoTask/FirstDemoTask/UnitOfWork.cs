using FirstDemoTask.Models;
using FirstDemoTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoTask
{
    public class UnitOfWork : IDisposable
{
    private MobileContext db;

    private OrderRepository orderRepository;
    private PhoneRepository phoneRepository;

        public UnitOfWork(MobileContext db, OrderRepository orderRepository, PhoneRepository phoneRepository)
        {
            this.db = db;
            this.orderRepository = orderRepository;
            this.phoneRepository = phoneRepository;
        }

        public OrderRepository Orders
    {
        get
        {  
            return orderRepository;
        }
    }

        public PhoneRepository Phones
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new PhoneRepository(db);
                return phoneRepository;
            }
        }

        public void Save()
    {
        db.SaveChanges();
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
}
