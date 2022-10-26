using Core.Utilities.Results.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IYoneticiService
    {
        public IDataResult<List<Yonetici>> GetAll();
        public IDataResult<Yonetici> Get(int yoneticiId);
        public IDataResult<Yonetici> Auth(string user,string pwd);
    }
}
