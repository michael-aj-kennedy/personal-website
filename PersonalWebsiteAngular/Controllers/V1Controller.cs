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
    public class V1Controller : Controller
    {
        private readonly AppSettings _config;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public V1Controller(IOptionsSnapshot<AppSettings> config, IWebHostEnvironment hostingEnvironment)
        {
            _config = config.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("v1")]
        public ActionResult Index()
        {
            if (Request.Scheme.Equals("http", StringComparison.InvariantCultureIgnoreCase) &&
                $"{Request.Host}{Request.Path}{Request.QueryString}".IndexOf("mikekennedy", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                var targetUrl = "https://www.mikekennedy.co.uk";
                return Redirect(targetUrl);
            }
            else
            {
                var model = new Models.Blog();
                return View("Blog", model);
            }
        }

        [Route("v1/Blog")]
        public ActionResult Blog()
        {
            var model = new Models.Blog();
            return View("Blog", model);
        }

        [Route("v1/Blog/{id}")]
        public ActionResult Blog(int id)
        {
            var model = new Models.Blog(id).BlogData.FirstOrDefault();

            model.Content = (model.Content ?? "")
                .Replace("=\"Content/", "=\"../../../Content/")
                .Replace("='Content/", "='../../../Content/")
                .Replace("=\"../../Content/", "=\"../../../Content/")
                .Replace("='../../Content/", "='../../../Content/");

            return View("Entry", model);
        }

        [Route("v1/Blog/Entry/{id}")]
        public ActionResult Entry(int id)
        {
            var model = new Models.Blog(id).BlogData.FirstOrDefault();

            model.Content = (model.Content ?? "")
                .Replace("=\"Content/", "=\"../../../Content/")
                .Replace("='Content/", "='../../../Content/")
                .Replace("=\"../../Content/", "=\"../../../Content/")
                .Replace("='../../Content/", "='../../../Content/");

            return View("Entry", model);
        }

        [Route("v1/Cv")]
        public ActionResult Cv()
        {
            var model = new Models.CV();
            return View("Index", model);
        }

        [Route("v1/Cv/ExperienceItem/{id}")]
        public ActionResult ExperienceItem(int id)
        {
            var model = BlogOperations.GetExperienceItem(id);
            return PartialView("ExperienceItem", model);
        }

    }
}