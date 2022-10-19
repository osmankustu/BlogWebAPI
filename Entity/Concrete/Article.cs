using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Article : IEntity
    {
       public  int ArticleId { get; set; }
       public string ArticleTitle { get; set; }
       public string ArticleSummary { get; set; }
       public  string ArticleContent { get; set; }
       public string ArticleImage { get; set; }
       public DateTime ArticleDate { get; set; }
       public int CategoryId { get; set; }

    }
}
