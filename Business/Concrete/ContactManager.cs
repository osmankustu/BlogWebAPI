using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_efContactDal.GetAll());
        }

        public IDataResult<Contact> GetByContactİd(int contactId)
        {
            return new SuccessDataResult<Contact>(_efContactDal.Get(c => c.ContactId == contactId)); 
        }
    }
}
