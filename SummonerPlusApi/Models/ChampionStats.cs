using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummonerPlusApi.Models
{
   
    public class ChampionStats
    {
        [JsonProperty("attackrange")]
        public decimal AttackRange { get; set; }

        [JsonProperty("mpperlevel")]
        public decimal MpPerLevel { get; set; }
        
        [JsonProperty("mp")]
        public decimal Mp { get; set; }

        [JsonProperty("attackdamage")]
        public decimal AttackDamage { get; set; }

        [JsonProperty("hp")]
        public decimal Hp { get; set; }

        [JsonProperty("hpperlevel")]
        public decimal HpPerLevel { get; set; }

        [JsonProperty("attackdamageperlevel")]
        public decimal AttackDamagePerLevel { get; set; }

        [JsonProperty("armor")]
        public decimal Armor { get; set; }

        [JsonProperty("mpregenperlevel")]
        public decimal MpRegenPerLevel { get; set; }

        [JsonProperty("hpregen")]
        public decimal HpRegen { get; set; }

        [JsonProperty("critperlevel")]
        public decimal CritPerLevel { get; set; }

        [JsonProperty("spellblockperlevel")]
        public decimal SpellBlockPerLevel { get; set; }

        [JsonProperty("mpregen")]
        public decimal MpRegen { get; set; }

        [JsonProperty("attackspeedperlevel")]
        public decimal AttackSpeedPerLevel { get; set; }

        [JsonProperty("spellblock")]
        public decimal SpellBlock { get; set; }

        [JsonProperty("movespeed")]
        public decimal MoveSpeed { get; set; }

        [JsonProperty("attackspeedoffset")]
        public decimal AttackSpeedOffset { get; set; }

        [JsonProperty("crit")]
        public decimal Crit { get; set; }

        [JsonProperty("hpregenperlevel")]
        public decimal HpRegenPerLevel { get; set; }

        [JsonProperty("armorperlevel")]
        public decimal ArmorPerLevel { get; set;}
    }
}