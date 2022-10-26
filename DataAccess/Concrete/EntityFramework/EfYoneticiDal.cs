using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfYoneticiDal : EfEntityRepositoryBase<Yonetici, BlogContext>, IYoneticiDal
    {
        public List<YoneticiDto> GetArticleDetails()
        {
            throw new NotImplementedException();
        }
    }
}
