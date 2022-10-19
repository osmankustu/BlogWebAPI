using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        public List<Contact> GetAll();
        public Contact GetByContactİd(int contactId);

    }
}
