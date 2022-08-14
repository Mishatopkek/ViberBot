using Newtonsoft.Json;

namespace ViberBot.Models.SendMessage;

public class Button
{
    [JsonProperty("ActionType")]
    public string? ActionType;

    [JsonProperty("ActionBody")]
    public string? ActionBody;

    [JsonProperty("Text")]
    public string? Text;

    [JsonProperty("TextSize")]
    public string? TextSize;
    
    [JsonProperty("Columns")]
    public int? Columns { get; set; }

    [JsonProperty("Rows")]
    public int? Rows { get; set; }

    [JsonProperty("BgColor")]
    public string BgColor { get; set; }
}