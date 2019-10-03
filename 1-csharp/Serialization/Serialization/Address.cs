using Newtonsoft.Json;

namespace Serialization
{
    public class Address
    {
        [JsonProperty("StreetAddress")]
        public string Street { get; set; }
        public string City { get; set; }

        [JsonIgnore]
        public string State { get; set; }
    }
}
