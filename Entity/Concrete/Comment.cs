using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string CommentName { get; set; }
        public string CommentEmail { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool commentStatus { get; set; }
        public int ArticleId { get; set; }

    }
}
