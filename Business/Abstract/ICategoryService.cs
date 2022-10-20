using Core.Utilities.Results.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService 
    {
       public IDataResult<List<Category>> GetAll();

       public IDataResult<Category> GetById(int CategoryId);
    }
}
