using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public class UserActivity
    {
		public long Id { get; set; }
		public DateTime Dt { get; set; }
		public long AsId { get; set; }
		public long GeoId { get; set; }
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public string ArticleSubTitle { get; set; }
		public bool IsBot { get; set; }
		public string LanguageInfo { get; set; }
		public string Referrer { get; set; }
		public string SourceUrl { get; set; }
		public int PageHeight { get; set; }
		public int PageWidth { get; set; }
	}
}
