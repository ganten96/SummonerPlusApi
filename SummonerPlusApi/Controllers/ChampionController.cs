﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public Dictionary<string, Champion> GetChampions()
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://global.api.pvp.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/lol/static-data/na/v1.2/champion?api_key=" + apiKey).Result;
                if (response != null)
                {
                    try
                    {
                        HttpContent content = response.Content;
                        string jsonContent = content.ReadAsStringAsync().Result;
                        var jObj = JObject.Parse(jsonContent);
                        var data = (JObject)jObj["data"];
                        Dictionary<string, Champion> champions = JsonConvert.DeserializeObject<Dictionary<string, Champion>>(data.ToString());
                        return champions;
                    }
                    catch (Exception ex)
                    {
                        string exception = ex.Message;
                        return null;
                    }
                }
                return null;
            }
        }

        //public Champion GetChampion(int championId)
        //{
        //    string apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(@"https://global.api.pvp.net/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = client.GetAsync("api/lol/static-data/na/v1.2/champion?api_key=" + apiKey).Result;
        //        if (response != null)
        //        {
        //            try
        //            {
        //                HttpContent content = response.Content;
        //                string jsonContent = content.ReadAsStringAsync().Result;
        //                var jObj = JObject.Parse(jsonContent);
        //                var data = (JObject)jObj["data"];
        //                Dictionary<string, Champion> champions = JsonConvert.DeserializeObject<Dictionary<string, Champion>>(data.ToString());
        //                return champions;
        //            }
        //            catch (Exception ex)
        //            {
        //                string exception = ex.Message;
        //                return null;
        //            }
        //        }
        //        return null;
        //    }
        //}
    }
}