using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public static class PhoneInitialization
    {
        public static void Initialize(ShopDbContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone 6S",
                        Company = "Apple",
                        Price = 700,
                        ReleaseDate = new DateTime(2016, 6, 1)
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 650,
                        ReleaseDate = new DateTime(2017, 8, 14)
                    },
                    new Phone
                    {
                        Name = "Lumia 950",
                        Company = "Microsoft",
                        Price = 500,
                        ReleaseDate = new DateTime(2015, 11, 11)
                    },
                    new Phone
                    {
                        Name = "Meize M5",
                        Company = "Meizu",
                        Price = 400,
                        ReleaseDate = new DateTime(2018, 1, 18)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
