using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AniAPIEpisodesIntegration.Models
{
    public class EpisodesListResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("documents")]
        public List<Episode> Episodes { get; set; }
    }

    public class Episode
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("anime_id")]
        public int AnimeID { get; set; }
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("video")]
        public string VideoURL { get; set; }
        [JsonPropertyName("source")]
        public string Source { get; set; }
        [JsonPropertyName("locale")]
        public string Locale { get; set; }
    }
}
