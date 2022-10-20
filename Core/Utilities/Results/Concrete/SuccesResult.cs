using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccesResult : Result
    {
        public SuccesResult(string message) : base(true)
        {

        }

        public SuccesResult() : base(true)
        {

        }

    }
}
