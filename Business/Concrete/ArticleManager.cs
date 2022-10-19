using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> GetAll()
        {
            //iş kodları
            return _articleDal.GetAll();
        }

        public List<Article> GetAllByCategory(int CategoryId)
        {
            return _articleDal.GetAll();
        }
    }
}
