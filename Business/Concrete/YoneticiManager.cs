using Business.Abstract;
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

        public Yonetici Get(int yoneticiId)
        {
            return _yoneticiDal.Get(y => y.YoneticiId == yoneticiId);
        }

        public List<Yonetici> GetAll()
        {
            return _yoneticiDal.GetAll();
        }
    }
}
