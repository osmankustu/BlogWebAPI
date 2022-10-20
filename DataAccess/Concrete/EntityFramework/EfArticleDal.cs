using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, BlogContext>, IArticleDal
    {
        public List<ArticleDetailDTO> GetArticleDetails()
        {
            using (BlogContext context = new BlogContext())
            {
                var result = from a in context.Article_Tbl
                             join c in context.Category_Tbl
                             on a.CategoryId equals c.CategoryId
                             select new ArticleDetailDTO 
                             {
                                 ArticleId = a.ArticleId ,
                                 ArticleTitle = a.ArticleTitle ,
                                 ArticleSummary = a.ArticleSummary ,
                                 ArticleContent= a.ArticleContent,
                                 CategoryName =
                                 c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
