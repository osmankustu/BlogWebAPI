using Entites.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic Constranint
    //Class: Referans Tip Olabilir
    //IEntity :IEntity Olabilir veya IEntity implemente eden bi nesne olabilir.
    //new : newlenebilir olmalı 
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);

    }
}
