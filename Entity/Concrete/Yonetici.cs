using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Yonetici : IEntity
    {
        public int YoneticiId { get; set; }
        public string YoneticiAdi { get; set; }
        public string YoneticiKullaniciAdi { get; set; }
        public string YoneticiSifre { get; set; } 
    }
}
