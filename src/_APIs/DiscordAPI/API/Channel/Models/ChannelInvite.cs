﻿using Newtonsoft.Json;

namespace DiscordAPI.API.Channel.Models
{
    public class ChannelInvite
    {
        [JsonProperty("max_age")]
        public int MaxAge { get; set; }
        [JsonProperty("max_uses")]
        public int MaxUses { get; set; }
        [JsonProperty("temporary")]
        public bool Temporary { get; set; }
    }
}
