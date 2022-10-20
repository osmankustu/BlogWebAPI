using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class YoneticiManager : IYoneticiService
    {
        IYoneticiDal _yoneticiDal;

        public YoneticiManager(IYoneticiDal yoneticiDal)
        {
            _yoneticiDal = yoneticiDal;
        }

        public IDataResult<Yonetici>Get(int yoneticiId)
        {
            return new SuccessDataResult<Yonetici>(_yoneticiDal.Get(y => y.YoneticiId == yoneticiId)) ;
        }

        public IDataResult<List<Yonetici>> GetAll()
        {
            return  new SuccessDataResult<List<Yonetici>>(_yoneticiDal.GetAll());
        }
    }
}
