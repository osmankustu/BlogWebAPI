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
            CategoryTests();
            ArticleTests();
            CommentTests();
            ContactTests();
            YoneticiTests();
        }

        private static void YoneticiTests()
        {
            //Yonetici Test
            YoneticiManager yoneticiManager = new YoneticiManager(new EfYoneticiDal());
            foreach (var yonetici in yoneticiManager.GetAll())
            {
                Console.WriteLine(yonetici.YoneticiAdi);
            }
        }

        private static void ContactTests()
        {
            //Contact Test
            ContactManager contactManager = new ContactManager(new EfContactDal());

            foreach (var contact in contactManager.GetAll())
            {
                Console.WriteLine(contact.ContactName);
            }
        }

        private static void CommentTests()
        {
            //Comment Test
            CommentManager commentManager = new CommentManager(new EfCommentDal());

            foreach (var comment in commentManager.GetAll())
            {
                Console.WriteLine(comment.CommentContent);
            }
        }

        private static void ArticleTests()
        {
            //Article Test
            ArticleManager articleManager = new ArticleManager(new EfArticleDal());

            foreach (var article in articleManager.GetAllByCategoryId(1))
            {
                Console.WriteLine(article.ArticleTitle);
            }
        }

        private static void CategoryTests()
        {
            //Cattegory Test
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetById(2))
            {
                Console.WriteLine(category.CategoryName);


            }
        }
    }
}
