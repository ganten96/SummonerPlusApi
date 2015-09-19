using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummonerPlusApi.Models
{
    public class Game
    {
        [JsonProperty(PropertyName = "championId")]
        public int ChampionID { get; set; }

        [JsonProperty(PropertyName = "createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty(PropertyName = "gameId")]
        public int GameID { get; set; }

        [JsonProperty(PropertyName = "gameMode")]
        public string GameMode { get; set; }

        [JsonProperty(PropertyName = "gameType")]
        public string GameType { get; set; }

        [JsonProperty(PropertyName = "spell1")]
        public int Spell1 { get; set; }

        [JsonProperty(PropertyName = "spell2")]
        public int Spell2 { get; set; }

        [JsonProperty(PropertyName = "fellowPlayers")]
        public List<Player> FellowPlayers { get; set; }

        [JsonProperty(PropertyName = "subType")]
        public string SubType { get; set;}

        [JsonProperty(PropertyName = "teamId")]
        public int TeamID { get; set; }

        [JsonProperty(PropertyName = "stats")]
        public Stats Stats { get; set; }
    }
}