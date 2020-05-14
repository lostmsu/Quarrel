﻿// Copyright (c) Quarrel. All rights reserved.

using DiscordAPI.Models.Messages.Embeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DiscordAPI.Models.Messages
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
        [JsonProperty("activity")]
        public Activity Activity { get; set; }
        [JsonProperty("author")]
        public User User { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("call")]
        public Call Call { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("edited_timestamp")]
        public DateTime? EditedTimestamp { get; set; }
        [JsonProperty("tts")]
        public bool TTS { get; set; }
        [JsonProperty("mention_everyone")]
        public bool MentionEveryone { get; set; }
        [JsonProperty("mentions")]
        public IEnumerable<User> Mentions { get; set; }
        [JsonProperty("mention_roles")]
        public IEnumerable<string> MentionRoles { get; set; }
        [JsonProperty("attachments")]
        public IEnumerable<Attachment> Attachments { get; set; }
        [JsonProperty("embeds")]
        public IEnumerable<Embed> Embeds { get; set; }
        [JsonProperty("reactions")]
        public IEnumerable<Reaction> Reactions { get; set; }
        [JsonProperty("nonce")]
        public long? Nonce { get; set; }
        [JsonProperty("pinned")]
        public bool Pinned { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("webhook_id")]
        public string WebHookid { get; set; }
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}