using Newtonsoft.Json;

namespace ViberBot.Models.SendMessage;

public class RichMedia
{
    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Buttons")]
    public List<Button> Buttons { get; set; }
}