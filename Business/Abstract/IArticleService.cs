using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<List<Article>> GetAll();

        IDataResult<List<Article>> GetAllByCategoryId(int CategoryId);

        IDataResult<List<ArticleDetailDTO>> GetArticleDetails();
        IDataResult<Article> GetById(int articleId);

        IResult add(Article article);
    }
}
