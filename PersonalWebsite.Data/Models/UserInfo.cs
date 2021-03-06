using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace PersonalWebsite.Data.Models
{
    public class UserInfo
    {
        public string UAS { get; set; }

        public AgentInfo AgentInfo { get; set; }
        public string AgentInfoError { get; set; }

        public bool IsBot
        {
            get
            {
                var uas = (UAS ?? "").ToLower();

                return
                    uas.Contains("bot") ||
                    uas.Contains("spider") ||
                    uas.Contains("crawl") ||
                    uas.Contains("archive") ||
                    uas.Contains("baiduspider") ||
                    uas.Contains("slurp") ||
                    uas.Contains("yahoo") ||
                    uas.Contains("ask jeeves") ||
                    uas.Contains("infoseek") ||
                    uas.Contains("lycos") ||
                    uas.Contains("yandex") ||
                    uas.Contains("mediapartners -google") ||
                    uas.Contains("feedfetcher -google") ||
                    uas.Contains("curious george");
            }
        }

        public string Language { get; set; }
        public string IpAddress { get; set; }
        public string IpHash { get; set; }
        public IpInfo IpInfo { get; set; }
        public string IpInfoError { get; set; }
    }
}
