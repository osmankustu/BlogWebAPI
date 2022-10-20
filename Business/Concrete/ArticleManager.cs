using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using Entites.DTOs;
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

        public IResult add(Article article)
        {
            //Bussines Codes
            _articleDal.Add(article);
            return new Result(true,"Ürün Eklendi");
        }

        public IDataResult<List<Article>> GetAll()
        {
            //iş kodları
            return new IDataResult(_articleDal.GetAll());
        }

        public IDataResult<List<Article>> GetAllByCategoryId(int CategoryId)
        {
            return _articleDal.GetAll(p=> p.CategoryId == CategoryId);
        }

        public IDataResult<List<ArticleDetailDTO>> GetArticleDetails()
        {
            return _articleDal.GetArticleDetails();
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return _articleDal.Get(a => a.ArticleId == articleId);
        }

        
    }
}
