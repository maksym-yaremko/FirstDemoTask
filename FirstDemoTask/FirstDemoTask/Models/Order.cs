using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoTask.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserSurname { get; set; }

        public string Email { get; set; }

        [Required]
        public string ContactPhone { get; set; } 

        [Required]
        public DateTime date { get; set; }

        public int PhoneId { get; set; } 
        public Phone Phone { get; set; }
    }
}
