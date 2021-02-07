using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using PersonalWebsite.Data.Models.Application;
using PersonalWebsite.Data.Models.Operations;
using PersonalWebsiteAngular.Models;
using PersonalWebsite.Data.Models;

namespace PersonalWebsiteAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V2Controller : Controller
    {
        private readonly AppSettings _config;

        public V2Controller(IOptionsSnapshot<AppSettings> config)
        {
            _config = config.Value;
        }

        //get menu items
        [HttpGet, Route("Menu")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public PageInfo GetMenu(string itemType = "", bool loadArticle = true)
        {
            var returnData = new PageInfo();

            //get menu items
            returnData.MenuItems = BlogOperations.GetMenuItems();
            returnData.Articles = new List<Article>();

            //select default menu item
            if (string.IsNullOrWhiteSpace(itemType))
            {
                returnData.MenuItems.FirstOrDefault(m => m.Type == "about").Selected = true;
            }
            else if (!string.IsNullOrWhiteSpace(itemType) &&
                returnData.MenuItems.Any(m => m.Type == itemType))
            {
                returnData.MenuItems.FirstOrDefault(m => m.Type == itemType).Selected = true;
            }
            
            if (!returnData.MenuItems.Any(m => m.Selected))
            {
                returnData.MenuItems.FirstOrDefault(m => m.Type == "blog").Selected = true;
            }

            return returnData;
        }

        [HttpGet, Route("Articles")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public List<Article> GetArticles(string itemType)
        {
            return BlogOperations.GetArticles(itemType);
        }


        //get article
        [HttpGet, Route("Article"), ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public Article GetArticle(string itemType, string articleId)
        {
            return BlogOperations.GetArticle(itemType, articleId);
        }
    }
}