using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
    //SOLID
    //Open Closed Principle
{
    public class Program
    {
        static void Main(string[] args)
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(category.CategoryName);
                

            }
            
            ArticleManager articleManager = new ArticleManager(new EfArticleDal());

            foreach (var article in articleManager.GetAllByCategoryId(1))
            {
                Console.WriteLine(article.ArticleTitle);
            }
            
            CommentManager commentManager = new CommentManager(new EfCommentDal());

            foreach (var comment in commentManager.GetAll()) 
            {
                Console.WriteLine(comment.CommentContent);
            }
            
        }
    }
}
