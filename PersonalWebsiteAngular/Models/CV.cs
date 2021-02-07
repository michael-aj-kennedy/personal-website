using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalWebsite.Data.Models;
using PersonalWebsite.Data.Models.Operations;

namespace PersonalWebsiteAngular.Models
{
    public class CV
    {
        public List<Skill> Skills { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }

        public CV()
        {
            Education = BlogOperations.GetEducation().OrderByDescending(e => e.Year).ToList();
            Experience = BlogOperations.GetExperience()
                .Where(e => e.Id > 0)
                .ToList();
            Skills = BlogOperations.GetSkills();
        }
    }
}