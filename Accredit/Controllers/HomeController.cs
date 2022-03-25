using Accredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Accredit.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> SearchUser(string user)
        {
            ViewBag.ErrorMessage = "";

            string Baseurl = "https://api.github.com/users/";

            User User = new User();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Accredit", "1"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(user);

                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(UserController.Index), "User", new { user = user });
                }
                else
                {
                    ViewBag.ErrorMessage = "User not found: " + user;
                    return View("Index");
                }
            }
        }
    }
}