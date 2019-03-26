using FirstDemoTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoTask.Data
{
    public static class PhoneInicialization
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone 8",
                        Company = "Apple",
                        Price = 900,
                        ReleaseYear= new DateTime(2017, 7, 20)
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy S6",
                        Company = "Samsung",
                        Price = 500,
                        ReleaseYear= new DateTime(2015, 3, 16)
                    },
                    new Phone
                    {
                        Name = "Lumia 950",
                        Company = "Microsoft",
                        Price = 500,
                        ReleaseYear = new DateTime(2016, 9, 25)
                    },
                    new Phone
                    {
                        Name = "Meizu M6",
                        Company = "Meizu",
                        Price = 700,
                        ReleaseYear = new DateTime(2018, 1, 22)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
