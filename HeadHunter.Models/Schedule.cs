﻿using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Schedule
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
