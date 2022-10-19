using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        public List<Comment> GetAll();

        public List<Comment> GetAllByCategoryId(int CategoryId);
    }
}
