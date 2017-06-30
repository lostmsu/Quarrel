﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_UWP.SharedModels;
using Newtonsoft.Json;

namespace Discord_UWP.DiscordAPI.Gateway.DownstreamEvents
{
    public struct MessageReactionUpdate
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }
    public struct MessageReactionRemoveAll
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
    }
}
