using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class About : IEntity
    {
        public int AboutId { get; set; }
        public string AboutName { get; set; }
        public string AnoutText { get; set; }
    }
}
