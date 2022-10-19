﻿using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryCount { get; set; }
        public int CategoryAded { get; set; }
    }
}
