using Demo.Models;
using Demo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class UnitOfWork
    {
        private ShopDbContext context;
        private OrderRepository orderRepository;
        private UserRepository userRepository;
        private PhoneRepository phoneRepository;

        public UnitOfWork(ShopDbContext context)
        {
            this.context = context;
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(context);
                }
                return orderRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public PhoneRepository PhoneRepository
        {
            get
            {
                if (this.phoneRepository == null)
                {
                    this.phoneRepository = new PhoneRepository(context);
                }
                return phoneRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
