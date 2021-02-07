using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class Blog
    {
        public Blog()
        {
            BlogCrossPosts = new HashSet<BlogCrossPost>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string HeaderImage { get; set; }
        public bool Pinned { get; set; }
        public bool? Hidden { get; set; }
        public string AccentColour { get; set; }
        public string TitleTextColour { get; set; }
        public string ItemType { get; set; }

        public virtual ICollection<BlogCrossPost> BlogCrossPosts { get; set; }
    }
}
