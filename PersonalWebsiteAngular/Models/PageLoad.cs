using PersonalWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsiteAngular.Models
{
    public class PageInfo
    {
        public List<ItemType> MenuItems { get; set; }
        public List<Article> Articles { get; set; }
        public Article Article { get; set; }
    }
}
