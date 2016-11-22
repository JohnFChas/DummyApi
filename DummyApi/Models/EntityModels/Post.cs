using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DummyApi.Models.EntityModels
{
    [JsonObject]
    [Table("posts")]
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("postDate")]
        public DateTime PostDate { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("upvotes")]
        public int Upvotes { get; set; } = 0;
        [JsonProperty("downvotes")]
        public int Downvotes { get; set; } = 0;

        [JsonProperty("threadId")]
        public int ThreadId { get; set; }
        [JsonIgnore]
        public virtual Thread Thread { get; set; }
    }
}