using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : ICommentDal
    {

        public void Add(Comment entity)
        {
            using (BlogContext context = new BlogContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Comment entity)
        {
            using (BlogContext context = new BlogContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Comment Get(Expression<Func<Comment, bool>> filter)
        {
            using (BlogContext context = new BlogContext())
            {
                return context.Set<Comment>().SingleOrDefault(filter);
            }
           
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            using (BlogContext context = new BlogContext())
            {
                return filter == null
                    ? context.Set<Comment>().ToList()
                    : context.Set<Comment>().Where(filter).ToList();
            }
        }

        public void Update(Comment entity)
        {
             using (BlogContext context = new BlogContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
