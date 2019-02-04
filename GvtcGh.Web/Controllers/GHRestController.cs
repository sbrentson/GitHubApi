using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace GvtcGh.Web.Controllers
{
    public class GHRestController : ApiController
    {
        // GET api/ghrest
        //public async System.Threading.Tasks.Task<JArray> Get()//JArray
        public async System.Threading.Tasks.Task<string> Get()//JArray
        {
            HttpClient client = new HttpClient();
            string githubURL = "https://api.github.com/users/biomade/repos";
            string userAgent = "GVTCUA";
            string mediaType = "application/vnd.github.v3+json";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);

            //gets the repos for a user
            HttpResponseMessage response = await client.GetAsync(githubURL);
            var jsonAsString = await response.Content.ReadAsStringAsync();
            //dynamic parsedJSon = JsonConvert.DeserializeObject(jsonAsString);
            return jsonAsString;
        }

        public async System.Threading.Tasks.Task<string> Get(string id)
        {
            HttpClient client = new HttpClient();
            string githubURL = "https://api.github.com/users/" + id + "/repos";
            string userAgent = "GVTCUA";
            string mediaType = "application/vnd.github.v3+json";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);

            //gets the repos for a user
            HttpResponseMessage response = await client.GetAsync(githubURL);
            var jsonAsString = await response.Content.ReadAsStringAsync();
            //dynamic parsedJSon = JsonConvert.DeserializeObject(jsonAsString);
            return jsonAsString;
        }
        //public async System.Threading.Tasks.Task<Object> Get()//JArray
        //{
        //    HttpClient client = new HttpClient();
        //    string githubURL = "https://api.github.com/users/biomade/repos";
        //    string userAgent = "GVTCUA";
        //    string mediaType = "application/vnd.github.v3+json";

        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
        //    client.DefaultRequestHeaders.Add("User-Agent", userAgent);

        //    //gets the repos for a user
        //    HttpResponseMessage response = await client.GetAsync(githubURL);
        //    var jsonAsString = await response.Content.ReadAsStringAsync();
        //    //dynamic parsedJSon = JsonConvert.DeserializeObject(jsonAsString);
        //    dynamic dyn = JsonConvert.DeserializeObject<JToken>(jsonAsString).ToObject<List<ExpandoObject>>().Cast<dynamic>().ToList();

        //    return dyn;

        //}
    }
}
