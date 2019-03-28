using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int PhoneId { get; set; }
        public virtual Phone Phone { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
