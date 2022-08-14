using Newtonsoft.Json;

namespace ViberBot.Models;

public class Message
{
    [JsonProperty("text")] 
    public string Text { get; set; }
    
    [JsonProperty("Type")] 
    public string Type { get; set; }
}