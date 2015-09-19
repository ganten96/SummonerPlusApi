using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummonerPlusApi.Models
{
    public class Player
    {
        [JsonProperty(PropertyName = "championId")]
        public int ChampionID { get; set; }
        [JsonProperty(PropertyName = "summonerId")]
        public int SummonerID { get; set; }

        [JsonProperty(PropertyName = "teamId")]
        public int TeamID { get; set; }


    }
}