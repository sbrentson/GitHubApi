using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GvtcGh.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Octokit;

namespace GvtcGh.Web.Controllers
{
    public class GitHubController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Details(GitHubUser model)
        {
            ////per the githup api, do use anyomuous we have to send in a user agent
            ////otherwise the request is rejected
            var client = new GitHubClient(new ProductHeaderValue("gvtc"));

            var basicAuth = new Credentials(ConfigurationManager.AppSettings["GitHubP1"], ConfigurationManager.AppSettings["GitHubP2"]);
            client.Credentials = basicAuth;

            try
            {
              model.UserDetails = await client.User.Get(model.Login);
            }
            catch (ApiException ex)
            {
               model.Error= ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> GetRepoAsync(GitHubRepo model)
        {
            //call the passthrough api and return a string
            var jsonAsString = await new GHRestController().Get(model.Owner.ToLower());

            //now convert to ExpandoObject list
            dynamic dynList = JsonConvert.DeserializeObject<JToken>(jsonAsString).ToObject<List<ExpandoObject>>().Cast<dynamic>().ToList();
            var result = ((IEnumerable<dynamic>)dynList).Where(d => d.name.ToLower() == model.Name.ToLower()).ToList();
            return View("GetRepo", result);
        }
    }
}
