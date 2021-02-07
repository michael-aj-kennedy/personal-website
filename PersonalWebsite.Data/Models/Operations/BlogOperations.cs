using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PersonalWebsite.Data.Models.Operations
{
    public static class BlogOperations
    {
        public static List<ExperienceInfo> GetExperienceInfo(int experienceId)
        {
            var returnData = new List<ExperienceInfo>();

            using (var context = new BlogContext())
            {
                returnData = context.ExperienceInfos
                    .Where(i => i.ExperienceId == experienceId)
                    .ToList();
            }

            return returnData;
        }

        public static List<Skill> GetSkills()
        {
            var returnData = new List<Skill>();

            using (var context = new BlogContext())
            {
                returnData = context.Skills
                    .OrderBy(s => s.Id)
                    .ToList();
            }

            return returnData;
        }

        public static List<Experience> GetExperience()
        {
            var returnData = new List<Experience>();

            using (var context = new BlogContext())
            {
                returnData = context.Experiences
                    .OrderBy(s => s.Id)
                    .ToList();
            }

            foreach (var experience in returnData)
            {
                experience.ExperienceInfos = GetExperienceInfo(experience.Id);
            }

            return returnData;
        }

        public static Experience GetExperienceItem(int id)
        {
            var returnData = new List<Experience>();

            using (var context = new BlogContext())
            {
                returnData = context.Experiences
                    .Where(s => s.Id == id)
                    .OrderBy(s => s.Id)
                    .ToList();
            }

            foreach (var experience in returnData)
            {
                experience.ExperienceInfos = GetExperienceInfo(experience.Id);
            }

            return returnData.FirstOrDefault();
        }

        public static List<Education> GetEducation()
        {
            var returnData = new List<Education>();

            using (var context = new BlogContext())
            {
                returnData = context.Educations
                    .OrderBy(e => e.EducationType)
                    .ThenByDescending(e => e.Yr)
                    .ToList();
            }

            return returnData;
        }

        public static List<BlogCrossPost> GetBlogCrossPosts(int itemId)
        {
            var returnData = new List<BlogCrossPost>();

            using (var context = new BlogContext())
            {
                returnData = context.BlogCrossPosts
                    .Where(p => p.BlogId == itemId)
                    .OrderBy(p => p.IconCss)
                    .ToList();
            }

            return returnData;
        }

        public static List<Blog> GetBlogs(int itemId = 0)
        {
            var returnData = new List<Blog>();

            using (var context = new BlogContext())
            {
                if (itemId == 0)
                {
                    returnData = context.Blogs
                        .Where(b => b.Id > 0 && (!b.Hidden.HasValue || !b.Hidden.Value))
                        .OrderBy(b => b.Pinned)
                        .ThenByDescending(b => b.Date)
                        .Select(b => new
                        {
                            b.AccentColour,
                            b.Date,
                            b.HeaderImage,
                            b.Id,
                            b.ItemType,
                            b.Pinned,
                            b.Summary,
                            b.Title,
                            b.TitleTextColour
                        })
                        .ToList()
                        .Select(b => new Blog()
                        {
                            AccentColour = b.AccentColour,
                            Date = b.Date,
                            HeaderImage = b.HeaderImage,
                            Id = b.Id,
                            ItemType = b.ItemType,
                            Pinned = b.Pinned,
                            Summary = b.Summary,
                            Title = b.Title,
                            TitleTextColour = b.TitleTextColour
                        })
                        .ToList();
                }
                else
                {
                    returnData = context.Blogs
                        .Include(b => b.BlogCrossPosts)
                        .Where(b => b.Id == itemId)
                        .OrderByDescending(b => b.Date)
                        .ToList();

                    foreach (var blog in returnData)
                    {
                        blog.BlogCrossPosts = GetBlogCrossPosts(blog.Id);
                    }
                }
            }

            return returnData;
        }

        public static List<ItemType> GetMenuItems()
        {
            var returnData = new List<ItemType>();

            using (var context = new BlogContext())
            {
                returnData = context.ItemTypes                    
                    .ToList();

                returnData.ForEach(i =>
                {
                    if (i.Type != "about" &&
                        i.Type != "blog" &&
                        i.Type != "cv")
                    {
                        i.Visible = context.Blogs
                            .Count(b => b.ItemType.ToLower() == i.Type.ToLower()) > 0;
                    }
                    else
                    {
                        i.Visible = true;
                    }

                    if (i.Visible)
                    {
                        if (i.Type == "about")
                        {
                            i.Source = "Blog";
                            i.DefaultId = -1;
                        }
                        else if (i.Type == "cv")
                        {
                            i.Source = "Experience";
                            i.DefaultId = context.Experiences
                                .Include(e => e.ExperienceInfos)
                                .Where(e => e.Id > 0)
                                .OrderByDescending(e => e.SortOrder)
                                .FirstOrDefault()
                                .Id;
                        }
                        else
                        {
                            i.Source = "Blog";
                            i.DefaultId = context.Blogs
                                .Where(b => b.Id > 0 && b.Content != null && b.Content != "")
                                .OrderByDescending(b => b.Pinned)
                                .ThenByDescending(b => b.Date)
                                .FirstOrDefault()
                                .Id;
                        }
                    }
                });
            }

            return returnData
                .Where(i => i.Visible)
                .OrderBy(i => i.SortOrder)
                .ToList();
        }

        public static List<Article> GetArticles(string menuType, bool firstRecord = false)
        {
            var returnData = new List<Article>();

            //default to blog list
            if (string.IsNullOrWhiteSpace(menuType) || menuType == "about")
            {
                menuType = "blog";
            }

            using (var context = new BlogContext())
            {
                if (menuType == "cv" || menuType == "experience")
                {
                    //get from cv table
                    returnData = context.Experiences
                        .Select(e => new
                        {
                            e.Id,
                            e.Date,
                            e.Company,
                            e.Title,
                            e.Details,
                            e.CompanyLine,
                            e.CompanyLocation,
                            e.SortOrder,
                            HasContent = e.ExperienceInfos.Any()
                        })
                        .OrderByDescending(e => e.SortOrder >= 1000 ? e.SortOrder * -1 : e.SortOrder)
                        .Take(firstRecord ? 1 : 10000)
                        .ToList()
                        .Select(e => new Article()
                        {
                            Id = e.Id,
                            Type = menuType,
                            Date = e.Date,
                            Title = e.Company,
                            Subtitle = e.Title,
                            Summary = e.Details,
                            Content = "",
                            HeaderImage = "",
                            Pinned = false,
                            AccentColour = "",
                            TitleTextColour = "",
                            IsBlogEntry = false,
                            HasContent = e.HasContent,
                            IsUrl = false
                        })
                        .ToList();
                }
                else
                {
                    //get from blog table
                    returnData = context.Blogs
                        .Where(b =>
                            b.Id > 0 &&
                            (b.ItemType == menuType || b.ItemType == null || b.ItemType == "") &&
                            (!b.Hidden.HasValue || !b.Hidden.Value) &&
                            b.Date <= DateTime.UtcNow
                        )
                        .Select(b => new
                        {
                            b.Id,
                            b.Date,
                            b.Title,
                            b.Summary,
                            b.HeaderImage,
                            b.Pinned,
                            b.AccentColour,
                            b.TitleTextColour,
                            HasContent = b.Content != null && b.Content != "",
                            IsUrl = b.Content != null && b.Content.ToLower().StartsWith("http")
                        })
                        .OrderByDescending(r => r.Pinned)
                        .ThenByDescending(r => r.Date)
                        .Take(firstRecord ? 1 : 10000)
                        .ToList()
                        .Select(b => new Article()
                        {
                            Id = b.Id,
                            Type = menuType,
                            Date = b.Date.ToShortDateString(),
                            Title = b.Title,
                            Subtitle = "",
                            Summary = b.Summary,
                            Content = "",
                            HeaderImage = b.HeaderImage,
                            Pinned = b.Pinned,
                            AccentColour = b.AccentColour,
                            TitleTextColour = b.TitleTextColour,
                            IsBlogEntry = true,
                            HasContent = b.HasContent && !b.IsUrl,
                            IsUrl = b.IsUrl
                        })
                        .ToList();
                }
            }

            if (returnData.Any())
            {
                returnData.FirstOrDefault().Pinned = true;
            }            

            return returnData;
        }

        public static Article GetArticle(string menuType, string articleId)
        {
            var returnData = new Article();
            var articleInt = 0;

            if (!string.IsNullOrWhiteSpace(articleId))
            {
                int.TryParse(articleId, out articleInt);
                articleId = articleId.ToLower().Replace(" ", "-");
            }
            else
            {
                //get most recent article
                articleInt = GetArticles(menuType, true).First().Id;
            }

            using (var context = new BlogContext())
            {
                if (menuType == "cv" || menuType == "experience")
                {
                    if (articleId == "education" || articleId == "-1")
                    {
                        returnData = new Article()
                        {
                            Id = -1,
                            IsBlogEntry = false,
                            Title = "Education",
                            Subtitle = "",
                            Type = "cv",
                            Content = ""
                        };

                        var training = context.Educations
                            .Where(e => e.EducationType == "T")
                            .OrderByDescending(e => e.Yr)
                            .Select(e => 
                                "<tr class='education-row'><td class='education-year'><p>" + e.Yr + "</p></td>" +
                                "<td class='education-desc'><p class='education-item'>" + e.Name + "</p><p class='education-details'>" + e.Details + "</p></td></tr>"
                            )
                            .ToList();

                        returnData.Content +=
                            "<div class='article-header'><p>Training</p></div>" +
                            "<p><table class='education-table training-table'>" + string.Join("", training.ToArray()) + "</table></p>";

                        var education = context.Educations
                            .Where(e => e.EducationType == "E")
                            .OrderByDescending(e => e.Yr)
                            .Select(e =>
                                "<tr class='education-row'><td class='education-year'><p>" + e.Yr + "</p></td>" +
                                "<td class='education-desc'><p class='education-item'>" + e.Name + "</p><p class='education-details'>" + e.Details + "</p></td></tr>"
                            )
                            .ToList();

                        returnData.Content +=
                            "<div class='article-header'><p>Qualifications</p></div>" +
                            "<p><table class='education-table qualifications-table'>" + string.Join("", education.ToArray()) + "</table></p>";
                    }
                    else
                    {
                        returnData = context.Experiences
                            .Where(e =>
                                e.Id == articleInt ||
                                (e.Company + " " + e.Title).ToLower().Replace(" ", "-") == articleId
                            )
                            .Select(e => new
                            {
                                e.Id,
                                e.Date,
                                e.Company,
                                e.Title,
                                e.Details,
                                e.CompanyLine,
                                e.CompanyLocation,
                                Info = e.ExperienceInfos.Select(i => new
                                {
                                    i.Id,
                                    i.Title,
                                    i.Details
                                }),
                                HasContent = e.ExperienceInfos.Any()
                            })
                            .ToList()
                            .Select(e => new Article()
                            {
                                Id = e.Id,
                                Type = menuType,
                                Date = e.Date,
                                Title = e.Company,
                                Subtitle = e.Title,
                                Summary = e.Details,
                                Content = "",
                                HeaderImage = "",
                                Pinned = false,
                                AccentColour = "",
                                TitleTextColour = "",
                                IsBlogEntry = false,
                                HasContent = e.HasContent,
                                Info = e.Info.Select(i => new ExperienceInfo()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    Details = i.Details
                                }).ToList(),
                                IsUrl = false
                            })
                            .FirstOrDefault();
                    }
                }
                else
                {
                    returnData = context.Blogs
                        .Where(b =>
                            b.Id == articleInt ||
                            b.Title.ToLower().Replace(" ", "-") == articleId
                        )
                        .Select(b => new
                        {
                            b.Id,
                            b.Date,
                            b.Title,
                            b.Content,
                            b.Summary,
                            b.HeaderImage,
                            b.Pinned,
                            b.AccentColour,
                            b.TitleTextColour,
                            HasContent = b.Content != null && b.Content != "",
                            IsUrl = b.Content != null && b.Content.ToLower().StartsWith("http")
                        })
                        .ToList()
                        .Select(b => new Article()
                        {
                            Id = b.Id,
                            Type = menuType,
                            Date = b.Date.ToShortDateString(),
                            Title = b.Title,
                            Subtitle = "",
                            Summary = b.Summary,
                            Content = b.Content,
                            HeaderImage = b.HeaderImage,
                            Pinned = b.Pinned,
                            AccentColour = b.AccentColour,
                            TitleTextColour = b.TitleTextColour,
                            IsBlogEntry = true,
                            HasContent = b.HasContent && !b.IsUrl,
                            IsUrl = b.IsUrl
                        })
                        .FirstOrDefault();
                }
            }

            return returnData;
        }
    }
}
