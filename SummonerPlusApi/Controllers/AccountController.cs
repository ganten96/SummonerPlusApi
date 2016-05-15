using System;
using System.Net.Http;
using System.Web.Http;
using SummonerPlusApi.Models;
using System.Configuration;
using SummonerPlusApi.DB;
using System.Security.Cryptography;
using System.Text;

namespace SummonerPlusApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private SummonerDb db;
        private int saltLength = 32;
        public AccountController(SummonerDb db)
        {
            this.db = db;
        }

        private string apiKey = ConfigurationManager.AppSettings["ApiKey"];

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
            user.Password = hashPassword(user.Password);
            try
            {
                long summonerId = db.GetUser(user);
                if(summonerId > 0)
                {
                    return Ok(summonerId);
                }
                return Unauthorized();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("Create"), HttpPost]
        public IHttpActionResult CreateAccount(LeagueUser user)
        {
            user.Password = hashPassword(user.Password);
            try
            {
                long summonerID = db.CreateAccount(user);
                if (summonerID > 0)
                {
                    return Ok(summonerID);
                }
                return Unauthorized();
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        private string hashPassword(string password)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[saltLength];
            rng.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            password = password + salt;
            var hmac512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = hmac512.ComputeHash(bytes);
            string hashedPassword = Convert.ToBase64String(hash);
            return hashedPassword;
        }
    }
}
