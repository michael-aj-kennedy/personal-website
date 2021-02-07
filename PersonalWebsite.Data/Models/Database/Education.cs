using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public partial class Education
    {
        public int Id { get; set; }
        public int Yr { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string EducationType { get; set; }
    }
}
