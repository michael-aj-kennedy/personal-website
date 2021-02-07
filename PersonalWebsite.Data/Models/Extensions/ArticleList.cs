using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Data.Models
{
    public class ArticleList
    {
        public ArticleList()
        {
            Articles = new List<Article>();
        }

        public Article Article { get; set; }
        public List<Article> Articles { get; set; }
    }
}
