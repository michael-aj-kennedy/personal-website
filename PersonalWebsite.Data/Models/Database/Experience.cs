using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class Experience
    {
        public Experience()
        {
            ExperienceInfos = new HashSet<ExperienceInfo>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string CompanyLine { get; set; }
        public string CompanyLocation { get; set; }
        public int? SortOrder { get; set; }

        public virtual ICollection<ExperienceInfo> ExperienceInfos { get; set; }
    }
}
