using Octokit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GvtcGh.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly GitHubClient _client;

        public UserController()
        {
            _client = new GitHubClient(new ProductHeaderValue("GVTC"))
            {
                Credentials = new Credentials(
                    ConfigurationManager.AppSettings["GitHubP1"],
                    ConfigurationManager.AppSettings["GitHubP2"]
                )
            };
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Repositories(string username)
        {
            ViewBag.Username = username;
            IEnumerable<Repository> model = await _client.Repository.GetAllForUser(username);
            return View(model);
        }
    }
}