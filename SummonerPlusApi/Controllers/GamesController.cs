using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SummonerPlusApi.Models;
namespace SummonerPlusApi.Controllers
{
    public class GamesController : ApiController
    {
        [HttpGet, Route("api/Games/{summonerID}")]
        public IHttpActionResult Games(long summonerID)
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
            return Ok(new List<Game>());
        }
    }
}
