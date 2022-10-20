using Core.Utilities.Results.Abstract;
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
        public IDataResult<List<Comment>> GetAll();

        public IDataResult<Comment> GetAllByCategoryId(int CategoryId);
    }
}
