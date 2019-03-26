﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoTask.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime ReleaseYear { get; set; }
    }
}
