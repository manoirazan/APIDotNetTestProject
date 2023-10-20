using Newtonsoft.Json;

namespace DotNetTestProject.Models
{
    public class LocationProperties
    {
        public class RootLocation
        {
            [JsonProperty("post code")]
            public string postCode { get; set; }

            [JsonProperty("country")]
            public string country { get; set; }
            
            [JsonProperty("country abbreviation")]
            public string countryAbbreviation { get; set; }
            
            [JsonProperty("places")]
            public Place[] places { get; set; }
        }

        public class Place
        {
            [JsonProperty("place name")]
            public string placeName { get; set; }

            [JsonProperty("logitude")]
            public string longitude { get; set; }

            [JsonProperty("state")]
            public string state { get; set; }

            [JsonProperty("state abbreviation")]
            public string stateAbbreviation { get; set; }

            [JsonProperty("latitude")]
            public string latitude { get; set; }
        }    
    }
}
