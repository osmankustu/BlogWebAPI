using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        //overload ovverride
       public Result(bool succes, string message):this(succes)
        {
           Message = message;
        }
        public Result(bool succes)
        {
           Success = succes;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
