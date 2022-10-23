using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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
            //if(DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Article>>(Messages.MaintanceTime);
            //}
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(),Messages.ArticleListted);
        }

        public IDataResult<List<Article>> GetAllByCategoryId(int CategoryId)
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(p=> p.CategoryId == CategoryId));
        }

        public IDataResult<List<ArticleDetailDTO>> GetArticleDetails()
        {
            //if(DateTime.Now.Hour == 19)
            //{
            //    return new ErrorDataResult<List<ArticleDetailDTO>>( Messages.MaintanceTime);
            //}
            return new SuccessDataResult<List<ArticleDetailDTO>>(_articleDal.GetArticleDetails(),Messages.ArticleDetails);
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(a => a.ArticleId == articleId));
        }

        public IDataResult<List<Article>> GetMostPopular()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(a=> a.ArticleId == 2));
        }
        
    }
}
