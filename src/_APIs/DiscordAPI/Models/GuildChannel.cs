﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace DiscordAPI.Models
{
    public class GuildChannel : Channel
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("is_private")]
        public bool Private { get; set; }

        [JsonProperty("permission_overwrites")]
        public IEnumerable<Overwrite> PermissionOverwrites { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }

        [JsonProperty("user_limit")]
        public string UserLimit { get; set; }

        [JsonProperty("nsfw")]
        public bool NSFW { get; set; }
    }
}
