using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummonerPlusApi.Models
{
    public class Stats
    {
        [JsonProperty(PropertyName = "assists")]
        public int Assists { get; set; }

        [JsonProperty(PropertyName = "championsKilled")]
        public int ChampionsKilled { get; set; }

        [JsonProperty(PropertyName = "minionsKilled")]
        public int MinionsKilled { get; set; }

        [JsonProperty(PropertyName = "goldEarned")]
        public int GoldEarned { get; set; }

        [JsonProperty(PropertyName = "numDeaths")]
        public int NumDeaths { get; set; }
    }
}