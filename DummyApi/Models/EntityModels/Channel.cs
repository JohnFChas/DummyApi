using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DummyApi.Models.EntityModels
{
    [JsonObject]
    public class Channel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("messages")]
        public virtual List<Message> Messages { get; set; }
    }
}