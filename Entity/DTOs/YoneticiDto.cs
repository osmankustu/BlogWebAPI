using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class YoneticiDto : IDto
    {
        public string YoneticiKullaniciAdi { get; set; }
        public string YoneticiSifre { get; set; }
    }
}
