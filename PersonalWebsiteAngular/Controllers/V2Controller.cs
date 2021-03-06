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
using Newtonsoft.Json.Bson;
using UAParser;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;

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
        public PersonalWebsite.Data.Models.TabInfo GetMenu(string itemType = "", bool loadArticle = true)
        {
            var returnData = new PersonalWebsite.Data.Models.TabInfo();

            try
            {
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
            }
            catch (Exception ex)
            {
                returnData.Exception = ex.ToString();
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
        [HttpPost, Route("Article"), ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public Article GetArticle(string itemType, string articleId, [FromBody]BrowserInfo browserInfo)
        {
            var returnData = BlogOperations.GetArticle(itemType, articleId);

            Task.Run(() => BlogOperations.LogVisit(returnData.Id, returnData.Title, returnData.Subtitle, GetUserInfo(Request), browserInfo));

            return returnData;
        }

        private UserInfo GetUserInfo(HttpRequest request)
        {
            var userInfo = new UserInfo();

            if (request != null && request.Headers != null && request.HttpContext != null)
            {
                //browser language
                if (request.Headers.ContainsKey("Accept-Language"))
                {
                    userInfo.Language = request.Headers["Accept-Language"].FirstOrDefault() ?? "";
                }

                //get ip address
                if (request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    userInfo.IpAddress = request.Headers["X-Forwarded-For"].FirstOrDefault();
                }

                if (request.Headers.ContainsKey("REMOTE_ADDR") && string.IsNullOrWhiteSpace(userInfo.IpAddress))
                {
                    userInfo.IpAddress = request.Headers["REMOTE_ADDR"];
                }

                if (string.IsNullOrWhiteSpace(userInfo.IpAddress))
                {
                    userInfo.IpAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
                }

                if (!string.IsNullOrWhiteSpace(userInfo.IpAddress))
                {
                    var sha1 = System.Security.Cryptography.SHA1.Create();
                    byte[] buf = System.Text.Encoding.UTF8.GetBytes(userInfo.IpAddress);
                    byte[] hash = sha1.ComputeHash(buf, 0, buf.Length);
                    userInfo.IpHash = System.BitConverter.ToString(hash).Replace("-", "");
                }

                //user agent string
                if (request.Headers.ContainsKey("User-Agent"))
                {
                    userInfo.UAS = request.Headers["User-Agent"].FirstOrDefault() ?? "";
                }
            }

            return userInfo;
        }

        

        [HttpGet, Route("UserIpInfo")]
        public async Task<JsonResult> UserInfo()
        {
            var userInfo = GetUserInfo(Request);







            return new JsonResult(userInfo);
        }
        
    }
}