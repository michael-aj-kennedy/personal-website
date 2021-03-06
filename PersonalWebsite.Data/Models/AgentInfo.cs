using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Data.Models
{
    public class AgentInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("os")]
        public AgentInfoOS OS { get; set; }

        [JsonProperty("device")]
        public AgentInfoDevice Device { get; set; }

        [JsonProperty("browser")]
        public AgentInfoBrowser Browser { get; set; }
    }

    public class AgentInfoOS
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("family_code")]
        public string FamilyCode { get; set; }

        [JsonProperty("family_vendor")]
        public string FamilyVendor { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_large")]
        public string IconLarge { get; set; }
    }

    public class AgentInfoDevice
    {
        [JsonProperty("is_mobile_device")]
        public bool IsMobile { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("brand_code")]
        public string BrandCode { get; set; }

        [JsonProperty("brand_url")]
        public string BrandUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AgentInfoBrowser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("version_major")]
        public string VersionMajor { get; set; }

        [JsonProperty("engine")]
        public string Engine { get; set; }

    }
}
