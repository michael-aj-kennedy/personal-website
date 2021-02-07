using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class ExperienceInfo
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public virtual Experience Experience { get; set; }
    }
}
