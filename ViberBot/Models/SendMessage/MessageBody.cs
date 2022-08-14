using Newtonsoft.Json;

namespace ViberBot.Models.SendMessage;

public class MessageBody
{
    [JsonProperty("receiver")]
    public string? Receiver { get; set; }
    
    [JsonProperty("type")]
    public string? Type { get; set; }
    
    [JsonProperty("sender")]
    public Sender? Sender { get; set; }
    
    [JsonProperty("min_api_version")]
    public int? MinApiVersion { get; set; }

    [JsonProperty("tracking_data")]
    public string? TrackingData { get; set; }


    [JsonProperty("text")]
    public string? Text { get; set; }

    [JsonProperty("keyboard")]
    public Keyboard? Keyboard { get; set; }
    
    [JsonProperty("rich_media")]
    public RichMedia? RichMedia { get; set; }
}