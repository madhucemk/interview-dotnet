using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace GroceryStoreAPI.Model
{
    [ExcludeFromCodeCoverage]
    public class Customer
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}
