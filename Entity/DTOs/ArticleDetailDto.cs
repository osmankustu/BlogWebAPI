using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class ArticleDetailDTO : IDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string CategoryName { get; set; }
        public string ArticleSummary { get; set; }
        public string ArticleContent { get; set; }
        public DateTime ArticleDate { get; set; }

    }
}
