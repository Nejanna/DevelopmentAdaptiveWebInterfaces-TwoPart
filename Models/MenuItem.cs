﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

}
