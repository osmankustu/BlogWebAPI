using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryArticleDal : IArticleDal
    {
        List<Article> _articles;
        public InMemoryArticleDal()
        {
            //STACK HAFIZA TESTİ
            _articles=new List<Article>
            {
                new Article{ArticleId=1,
                            CategoryId=1,
                            ArticleTitle="Dünyanın Doğuşu",
                            ArticleSummary="dünya bilmem kaç yılında doğmuştur. çok güzel ",
                            ArticleContent="fadsfsadgdsahfasdgasdgfasdgasdgasdghsdfsdafasdgdsagasfasfasdgdsagasd",
                            ArticleDate=DateTime.Now,
                            
                            ArticleImage="fasdfdsafasfdsafdf"
                },
                new Article{ArticleId=1,
                            CategoryId=1,
                            ArticleTitle="İnternetin Doğuşu",
                            ArticleSummary="dünya bilmem kaç yılında doğmuştur. çok güzel ",
                            ArticleContent="fadsfsadgdsahfasdgasdgfasdgasdgasdghsdfsdafasdgdsagasfasfasdgdsagasd",
                            ArticleDate=DateTime.Now,
                            
                            ArticleImage="fasdfdsafasfdsafdf"
                },
                new Article{ArticleId=1,
                            CategoryId=1,
                            ArticleTitle=".NET BACKEND APİ NASIL KULLANILIR",
                            ArticleSummary="dünya bilmem kaç yılında doğmuştur. çok güzel ",
                            ArticleContent="fadsfsadgdsahfasdgasdgfasdgasdgasdghsdfsdafasdgdsagasfasfasdgdsagasd",
                            ArticleDate=DateTime.Now,
                            
                            ArticleImage="fasdfdsafasfdsafdf"
                },
                new Article{ArticleId=1,
                            CategoryId=1,
                            ArticleTitle="DİZAYN KALIPLARI NASIL KULLANILIR",
                            ArticleSummary="dünya bilmem kaç yılında doğmuştur. çok güzel ",
                            ArticleContent="fadsfsadgdsahfasdgasdgfasdgasdgasdghsdfsdafasdgdsagasfasfasdgdsagasd",
                            ArticleDate=DateTime.Now,
                            
                            ArticleImage="fasdfdsafasfdsafdf"
                }
            };
        }
        public void Add(Article article)
        {
            _articles.Add(article);
        }

        public void Delete(Article article)
        {
            //LINQ - Language Integrated Query 
            //Lamda
            Article articleToDelete;
            articleToDelete = _articles.SingleOrDefault(a=> a.ArticleId == article.ArticleId);
            _articles.Remove(articleToDelete);
        }

        public Article Get(Expression<Func<Article, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            return _articles;
        }

        public List<Article> GetAll(Expression<Func<Article, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllByCategory(int CategryId)
        {
            return _articles.Where(a => a.CategoryId == CategryId).ToList();           
        }

        public void Update(Article article)
        {
            Article articleToUpdate;
             articleToUpdate = _articles.SingleOrDefault(a => a.ArticleId == article.ArticleId);
             articleToUpdate.ArticleTitle = article.ArticleTitle;
             articleToUpdate.ArticleSummary = article.ArticleSummary;   
             articleToUpdate.ArticleContent = article.ArticleContent;
             articleToUpdate.ArticleDate = article.ArticleDate;
             articleToUpdate.ArticleImage = article.ArticleImage;
            
        }
    }
}
