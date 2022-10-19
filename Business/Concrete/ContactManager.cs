using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        EfContactDal _efContactDal;

        public ContactManager(EfContactDal efContactDal)
        {
            _efContactDal = efContactDal;
        }

        public List<Contact> GetAll()
        {
            return _efContactDal.GetAll();
        }

        public Contact GetByContactİd(int contactId)
        {
            return _efContactDal.Get(c=> c.ContactId == contactId); 
        }
    }
}
