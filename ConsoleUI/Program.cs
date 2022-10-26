using Business.Concrete;
using Core.Utilities.Results.Concrete;
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
    //IoC
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CategoryTests();
            //ArticleTests();
            //CommentTests();
            //ContactTests();
            //YoneticiTests();
        }

        private static void YoneticiTests()
        {
            //Yonetici Test
            
        }

        private static void ContactTests()
        {
            //Contact Test
            ContactManager contactManager = new ContactManager(new EfContactDal());

            var result = contactManager.GetAll(); 
            foreach (var contact in result.Data)
            {
                Console.WriteLine(contact.ContactName);
            }
        }

        private static void CommentTests()
        {
            //Comment Test
            CommentManager commentManager = new CommentManager(new EfCommentDal());
            var result = commentManager.GetAll();

            foreach (var comment in result.Data)
            {
                Console.WriteLine(comment.CommentContent);
            }
        }

        private static void ArticleTests()
        {
            //Article Test
            ArticleManager articleManager = new ArticleManager(new EfArticleDal(),new CategoryManager(new EfCategoryDal()));

            var result = articleManager.GetArticleDetails();

            if(result.Success==true)
            foreach (var article in result.Data) 
            {
                Console.WriteLine(article.ArticleTitle +"/" + article.CategoryName);
                    Console.WriteLine(result.Message);
                
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryTests()
        {
            //Cattegory Test
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result =categoryManager.GetAll();

            foreach (var category in result.Data)
            {
                Console.WriteLine(category.CategoryName);


            }
        }
    }
}
