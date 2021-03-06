using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Data.Models
{
    public class BrowserInfo
    {
        public string Referrer { get; set; }
        public string Url { get; set; }
        public int PageHeight { get; set; }
        public int PageWidth { get; set; }
    }
}
