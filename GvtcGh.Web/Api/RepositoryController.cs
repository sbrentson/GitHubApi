using Octokit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GvtcGh.Web.Api
{
    public class RepositoryController : ApiController
    {
        private readonly GitHubClient _client;

        public RepositoryController()
        {
            _client = new GitHubClient(new ProductHeaderValue("GVTC"))
            {
                Credentials = new Credentials(
                    ConfigurationManager.AppSettings["GitHubP1"],
                    ConfigurationManager.AppSettings["GitHubP2"]
                )
            };
        }

        public async Task<IHttpActionResult> Get(string username)
        {
            try
            {
                IEnumerable<Repository> repositories = await _client
                    .Repository
                    .GetAllForUser(username);

                return Ok(repositories);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return NotFound();
                }

                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Get(string username, int id)
        {
            try
            {
                Repository repository = (await _client
                    .Repository
                    .GetAllForUser(username)
                    ).FirstOrDefault(r => r.Id == id);

                return Ok(repository);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return NotFound();
                }

                return InternalServerError(ex);
            }
        }
    }
}