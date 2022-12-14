using Business.Abstract;
using Business.BusinesAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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

        //Authorizations
        [SecuredOperation("article.add,admin")]
        //Validations
        [ValidationAspect(typeof(ArticleValidator))]
        //Yeni Ürün eklendiğinde Cache'yi Boşat -sil
        [CacheRemoveAspect("IProductService.Get")]
        //Performans Testi
        [PerformanceAspect(5)]
        public IResult add(Article article)
        {
            //business Code
            IResult result =BusinessRules.Run(CheckIfArticleNameExists(article.ArticleTitle));
            if (result != null)
            {
                return result;
            }

            _articleDal.Add(article);
            return new SuccesResult(Messages.ArticleAdd);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Article>> GetAll()
        {
            IResult result = BusinessRules.Run(MaintanceTime());
            if (result != null)
            {
                return new ErrorDataResult<List<Article>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll());
            
        }
        
        public IDataResult<List<Article>> GetAllByCategoryId(int CategoryId)
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(p => p.CategoryId == CategoryId));
        }

        public IDataResult<List<ArticleDetailDTO>> GetArticleDetails()
        {
            
            return new SuccessDataResult<List<ArticleDetailDTO>>(_articleDal.GetArticleDetails(), Messages.ArticleDetails);
        }

        [CacheAspect]
        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(a => a.ArticleId == articleId));
        }

        public IDataResult<List<Article>> GetMostPopular()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetAll(a => a.ArticleId == 2));
        }

        //Authorizations
        [SecuredOperation("article.update,admin")]
        //validation rules
        [ValidationAspect(typeof(ArticleValidator))]
        //Bir veri güncellendiğinde belleği sil
        [CacheRemoveAspect("IProductService.Get")]
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
            if (DateTime.Now.Hour == 20)
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
            return new  SuccesResult(Messages.ArticleAdd);
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

        public IResult AddITransactionalTest(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
