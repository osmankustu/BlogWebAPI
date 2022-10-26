using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(a => a.ArticleTitle).MinimumLength(10).NotEmpty();
            RuleFor(a => a.ArticleContent).MinimumLength(10).NotEmpty();
            RuleFor(a => a.ArticleDate).NotEmpty();
            RuleFor(a => a.ArticleSummary).MinimumLength(10).NotEmpty();
            

        }
    }
}
