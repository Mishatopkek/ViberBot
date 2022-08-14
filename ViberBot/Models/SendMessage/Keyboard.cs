using Newtonsoft.Json;

namespace ViberBot.Models.SendMessage;

public class Keyboard
{
    [JsonProperty("Type")]
    public string Type;

    [JsonProperty("Buttons")]
    public List<Button> Buttons;
}