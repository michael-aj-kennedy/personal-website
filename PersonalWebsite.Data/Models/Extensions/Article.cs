using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Date { get; set; }

        private string _type = "";
        public string Type 
        { 
            get
            {
                return string.IsNullOrWhiteSpace(_type) ? "blog" : _type;
            }
            set
            {
                _type = value;
            }
        }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Summary { get; set; }

        private string _content = "";
        public string Content 
        { 
            get
            {
                var returnData = _content ?? "";

                if (string.IsNullOrWhiteSpace(returnData) && Info != null && Info.Any())
                {
                    foreach (var info in Info)
                    {
                        returnData += info.Title != null && info.Title != ""
                            ? $"<div class='experience-header'>{info.Title}</div><div class='experience-details'>{info.Details}</div>"
                            : $"<div class='experience-core'>{info.Details}</div>";
                    }
                }

                return returnData;
            }
            set
            {
                _content = value;
            }
        }
        public List<Education> EducationInfo { get; set; }
        public string HeaderImage { get; set; }
        public bool Pinned { get; set; }
        public string AccentColour { get; set; }
        public string TitleTextColour { get; set; }
        public bool IsBlogEntry { get; set; }
        public bool HasContent { get; set; }
        public bool IsUrl { get; set; }
        public List<ExperienceInfo> Info { get; set; }
        public string Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(Title) 
                    ? Id.ToString() 
                    : (Title + " " + Subtitle ?? "").Trim().Replace(" ", "-").ToLower();
            }
        }
        public bool HasSubTitle
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Subtitle);
            }
        }

        public bool ModeUrl
        {
            get
            {
                return IsUrl;
            }
        }

        public bool ModeArticle
        {
            get
            {
                return !IsUrl && HasContent;
            }
        }

        public bool ModeNoContent
        {
            get
            {
                return !IsUrl && !HasContent;
            }
        }


    }
}
