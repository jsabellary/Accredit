using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Accredit.Models;
using System.Threading.Tasks;
using System.Net;

namespace Accredit.Controllers
{
    public class UserController : Controller
    {
        // GET: Repos for User
        public async Task<ActionResult> Index(string user)
        {
            string Baseurl = "https://api.github.com/users/";

            User User = new User();
            using (var client = new HttpClient())
            {
                //specify to use TLS 1.2 as default connection
                //ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Accredit", "1"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(user);

                if (Res.IsSuccessStatusCode)
                {
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;

                    User = JsonConvert.DeserializeObject<User>(UserResponse);
                    using (var client2 = new HttpClient())
                    {
                        client2.BaseAddress = User.repos_url;
                        client2.DefaultRequestHeaders.Clear();
                        client2.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Accredit", "1"));
                        client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage Res2 = await client2.GetAsync("");

                        if (Res2.IsSuccessStatusCode)
                        {
                            var UserResponse2 = Res2.Content.ReadAsStringAsync().Result;
                            User.Repos = JsonConvert.DeserializeObject<List<Repo>>(UserResponse2);
                            User.Repos = User.Repos.OrderByDescending(x => x.stargazers_count).Take(5).ToList();
                        }
                    }
                }
            }
            return View(User);
        }
    }
}