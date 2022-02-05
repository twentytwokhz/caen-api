// Copyright (c) Florin Bobis. All Rights Reserved.

using System.Text.Json.Serialization;

namespace CAEN.Library.Models
{
    public class Section : ISearchableCaen
    {
        [JsonPropertyName("Sectiune")]
        public string ID { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("Diviziuni")]
        public List<Division> Divisions { get; set; } = new List<Division>();

        public bool Search(string query)
        {
            return ID.ToLower().Contains(query.ToLower()) ||
                Name.ToLower().Contains(query.ToLower());
        }
    }

    public class Division : ISearchableCaen
    {
        [JsonPropertyName("Diviziune")]
        public string ID { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("Grupe")]
        public List<Group> Groups { get; set; } = new List<Group>();

        public bool Search(string query)
        {
            return ID.ToLower().Contains(query.ToLower()) ||
                Name.ToLower().Contains(query.ToLower());
        }
    }

    public class Group : ISearchableCaen
    {
        [JsonPropertyName("Grupa")]
        public string ID { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("Clase")]
        public List<CaenCode> Codes { get; set; } = new List<CaenCode>();

        public bool Search(string query)
        {
            return ID.ToLower().Contains(query.ToLower()) ||
                Name.ToLower().Contains(query.ToLower());
        }
    }

    public class CaenCode : ISearchableCaen
    {
        [JsonPropertyName("CAENRev2")]
        public string CAENRev2 { get; set; }
        [JsonPropertyName("Denumire")]
        public string Name { get; set; }
        [JsonPropertyName("CAENRev1")]
        public string CAENRev1 { get; set; }
        [JsonPropertyName("ISICRev4")]
        public string ISICRev4 { get; set; }

        public bool Search(string query)
        {
            return Name.ToLower().Contains(query.ToLower()) ||
                CAENRev2.ToLower().Contains(query.ToLower()) ||
                CAENRev1.ToLower().Contains(query.ToLower()) ||
                ISICRev4.ToLower().Contains(query.ToLower());
        }
    }
}
