using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalWebsiteAngular.Models
{
    public class Blog
    {
        public List<PersonalWebsite.Data.Models.Blog> BlogData { get; set; }

        public Blog(int id = 0)
        {
            BlogData = PersonalWebsite.Data.Models.Operations.BlogOperations.GetBlogs(id);
        }
    }
}