using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace PersonalWebsite.Data.Models
{
    public class UserGeo
    {
		public long Id { get; set; }
		public DateTime Dt { get; set; }
		public string Identifier { get; set; }
		public string Response { get; set; }
	}
}
