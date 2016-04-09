using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SummonerPlusApi.Models;
using SummonerPlusApi.Providers;
using SummonerPlusApi.Results;
using System.Configuration;
using SummonerPlusApi.DB;
namespace SummonerPlusApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private SummonerDb db;

        public AccountController(SummonerDb db)
        {
            this.db = db;
        }

        private string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        [Route("Create"), HttpPost]
        public IHttpActionResult CreateAccount(LeagueUser user)
        {
            return null;
        }

        [Route("Verify"), HttpPost]
        public IHttpActionResult VerifySummonerName(string summonerName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://na.api.pvp.net/api/lol/na/v1.4/");
                var result = client.GetAsync("summoner/by-name/" + summonerName + "?api_key=" + apiKey).Result;

                try
                {
                    LeagueUser user = result.Content.ReadAsAsync<LeagueUser>().Result;
                    return Ok(user);
                }
                catch(Exception ex)
                {
                    return InternalServerError();
                }
            }
        }

        [Route("Login"), HttpPost]
        public IHttpActionResult LogIn(LeagueUser user)
        {
            return null;
        }

        private string GenerateToken(LeagueUser user)
        {
            return "";
        }
    }
}
