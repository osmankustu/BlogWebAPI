using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;


        public ArticleManager(IArticleDal articleDal, ICategoryService categoryService)
        {
            _articleDal = articleDal;
            _categoryService = categoryService;
        }



        [ValidationAspect(typeof(ArticleValidator))]
        public IResult add(Article article)
        {//business Code
         //Bir kategoride en fazla 10 makale olabilir

            IResult result =BusinessRules.Run(CheckIfArticleNameExists(article.ArticleTitle),
                CheckIfProductCountOfCategoryCorrect(article.CategoryId), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _articleDal.Add(article);
            return new SuccesResult(Messages.ArticleAdd);

        }



        public IDataResult<List<Article>> GetAll()
        {
            if (MaintanceTime().Success) 
                {
               
                return new SuccessDataResult<List<Article>>(_articleDal.GetAll(), Messages.ArticleListted);
            }
            return new ErrorDataResult<List<Article>>(Messages.MaintanceTime);
        }

        public IDataResult<List<Article>> GetAllByCategoryId(int CategoryId)
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(p => p.CategoryId == CategoryId));
        }

        public IDataResult<List<ArticleDetailDTO>> GetArticleDetails()
        {
            //if(DateTime.Now.Hour == 19)
            //{
            //    return new ErrorDataResult<List<ArticleDetailDTO>>( Messages.MaintanceTime);
            //}
            return new SuccessDataResult<List<ArticleDetailDTO>>(_articleDal.GetArticleDetails(), Messages.ArticleDetails);
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(a => a.ArticleId == articleId));
        }

        public IDataResult<List<Article>> GetMostPopular()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(a => a.ArticleId == 2));
        }

        [ValidationAspect(typeof(ArticleValidator))]
        public IResult Update(Article article)
        {//business Code
         //Bir kategoride en fazla 10 makale olabilir
            _articleDal.Update(article);
            return new Result(true, "Ürün Eklendi");

        }

        //Her Fonksiyonda Kullanaılabilecek İş Kuralını Tek seferde yazıp kod karmaşıklığından kurtuluyoruz.
        
        private IResult CheckIfProductCountOfCategoryCorrect(int CategoryId)
        {
            var result = _articleDal.GetAll(a => a.CategoryId == CategoryId).Count;

            if (result > 2)
            {
                return new ErrorResult(Messages.ArticleCountOfCategoryError);
            }

            return new SuccesResult();

        }

        private IResult MaintanceTime()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorResult(Messages.MaintanceTime);
            }
            return new SuccesResult();
        }

        private IResult CheckIfArticleNameExists(string ArticleTitle)
        {
            var result = _articleDal.GetAll(a => a.ArticleTitle == ArticleTitle).Any();
            if(result)
            {
                return new ErrorResult(Messages.ArticleNameExists);
            }
            return new  SuccesResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count > 2)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccesResult();
        }
       
    }
}
