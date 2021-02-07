using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class BlogTag1
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public int? BlogTagId { get; set; }
    }
}
