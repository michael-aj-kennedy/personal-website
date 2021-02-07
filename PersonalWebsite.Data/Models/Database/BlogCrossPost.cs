using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class BlogCrossPost
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public string BlogUrl { get; set; }
        public string Description { get; set; }
        public string IconCss { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
