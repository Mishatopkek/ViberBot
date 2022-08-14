using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ViberBot.Models;

public class MessageCallback
{
    [JsonProperty("event")]
    public string Event { get; set; }

    [JsonProperty("timestamp")]
    public long? Timestamp { get; set; }
    
    [JsonProperty("message_token")]
    public long? MessageToken { get; set; }

    [JsonProperty("sender")]
    public Sender? Sender { get; set; }
    
    [JsonProperty("message")] 
    public Message? Message { get; set; }
    
    [JsonPropertyName("chat_hostname")]
    public string? ChatHostname { get; set; }
}