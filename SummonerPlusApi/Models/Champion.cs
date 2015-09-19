using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace SummonerPlusApi.Models
{
    public class Champion
    {
        [JsonProperty(PropertyName = "id")]
        public long ChampionID { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string ChampionName { get; set; }

        [JsonProperty(PropertyName = "freeToPlay")]
        public bool FreeToPlay { get; set; }

        [JsonProperty(PropertyName = "rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; set; }

        [JsonProperty(PropertyName = "blurb")]
        public string Blurb { get; set; }

        [JsonProperty(PropertyName = "enemytips")]
        public List<string> EnemyTips { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "info")]
        public ChampionInfo Info { get; set; }
    }
}