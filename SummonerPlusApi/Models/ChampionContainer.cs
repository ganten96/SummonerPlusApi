using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummonerPlusApi.Models
{
    public class ChampionContainer
    {
        [JsonProperty(PropertyName = "data")]
        public List<Champion> Data { get; set; }
    }
}