using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Data.Models
{
    public class IpInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; } //success/fail

        [JsonProperty("message")]
        public string Message { get; set; } //failure message

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("isp")]
        public string ISP { get; set; }

        [JsonProperty("org")]
        public string Organisation { get; set; }

        [JsonProperty("mobile")]
        public bool IsMobile { get; set; }

        [JsonProperty("proxy")]
        public bool IsProxy { get; set; }
    }
}
