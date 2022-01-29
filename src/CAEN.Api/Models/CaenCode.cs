// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CAEN.Api.Models
{
    public class Section
    {
        [JsonPropertyName("Sectiune")]
        public string ID { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("Diviziuni")]
        public List<Division> Divisions { get; set; }
    }

    public class Division
    {
        [JsonPropertyName("Diviziune")]
        public string ID { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("Grupe")]
        public List<Group> Groups { get; set; }
    }

    public class Group
    {
        [JsonPropertyName("Grupa")]
        public string ID { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("Clase")]
        public List<CaenCode> Codes { get; set; }
    }

    public class CaenCode
    {
        [JsonPropertyName("CAENRev2")]
        public string CAENRev2 { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("CAENRev1")]
        public string CAENRev1 { get; set; }
        [JsonPropertyName("ISICRev4")]
        public string ISICRev4 { get; set; }
    }
}
