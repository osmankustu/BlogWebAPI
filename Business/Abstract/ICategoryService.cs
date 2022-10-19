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
       public List<Category> GetAll();

       public List<Category> GetAllByCategory(int CategoryId);
    }
}
