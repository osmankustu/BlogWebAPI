using DataAccess.Abstract;
using Entites.Concrete;
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
    public class EfArticleDal : IArticleDal
    {
        

        

        public void Add(Article entity)
        {
            //IDispossable pattern impelementation of c#
            using (BlogContext context = new BlogContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Article entity)
        {
            using (BlogContext context = new BlogContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Article Get(Expression<Func<Article, bool>> filter)
        {
            using (BlogContext context = new BlogContext())
            {
                return context.Set<Article>().SingleOrDefault(filter);
            }
        }

        public List<Article> GetAll(Expression<Func<Article, bool>> filter = null)
        {
            using (BlogContext context = new BlogContext())
            {
                return filter == null 
                    ? context.Set<Article>().ToList() 
                    : context.Set<Article>().Where(filter).ToList();
            }
        }

        public void Update(Article entity)
        {
            using (BlogContext context = new BlogContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
