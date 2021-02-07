using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalWebsite.Data.Models
{
    public partial class ItemType
    {
        [NotMapped]
        public bool Visible { get; set; }
        [NotMapped]
        public string Source { get; set; }
        [NotMapped]
        public int DefaultId { get; set; }
        [NotMapped]
        public bool Selected { get; set; }
    }
}
