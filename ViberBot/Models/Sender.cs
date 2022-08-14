using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ViberBot.Models;

public class Sender
{
    [JsonProperty("id")]
    public string? Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("avatar")]
    public string? Avatar { get; set; }
    
    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }
    
    [JsonPropertyName("api_version")]
    public double? ApiVersion { get; set; }
}