using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class UserForRegisterDto
    {
       public string Email { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Password { get; set; }
    }
}