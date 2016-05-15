using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummonerPlusApi.Models
{
    public class LeagueUser
    {
        [JsonProperty("name")]
        public string SummonerName { get; set; }

        [JsonProperty("id")]
        public long SummonerID { get; set; }
        
        //comes in hashed.
        public string Password { get; set; }

        public bool IsAuthenicated { get; }

        public string Token { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconID { get; set; }

        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        public string ProfileIconURL { get { return "http://ddragon.leagueoflegends.com/cdn/5.24.2/img/profileicon/" + ProfileIconID; } }
    }
}