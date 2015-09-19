using Newtonsoft.Json;
using SummonerPlusApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SummonerPlusApi.Controllers
{
    public class ChampionController : ApiController
    {
        public List<Champion> GetChampions()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://global.api.pvp.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/lol/static-data/na/v1.2/champion?api_key=" + apiKey);

                List<Champion> champs;
                if(response != null)
                {
                    ChampionContainer champions = response.Result.Content.ReadAsAsync<ChampionContainer>().Result;
                    champs = champions.Data;
                    return champs;
                }
                return null;
            }
        }
    }
}
