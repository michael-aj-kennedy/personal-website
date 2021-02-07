using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class ItemType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}