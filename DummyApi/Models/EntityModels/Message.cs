using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DummyApi.Models.EntityModels
{
    [JsonObject]
    [Table("messages")]
    public class Message
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("timeSent")]
        public DateTime TimeSent { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("channelId")]
        public int ChannelId { get; set; }
        [JsonIgnore]
        public virtual Channel Channel { get; set; }
    }
}