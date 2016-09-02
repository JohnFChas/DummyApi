using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DummyApi.Models.EntityModels
{
    [JsonObject]
    public class Message
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("timeSent")]
        public DateTime TimeSent { get; set; }
        [JsonProperty("body")]

        public int ChannelId { get; set; }
        [JsonProperty("channel")]
        public virtual Channel Channel { get; set; }
    }
}