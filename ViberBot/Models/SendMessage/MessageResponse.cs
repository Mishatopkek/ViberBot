using Newtonsoft.Json;

namespace ViberBot.Models.SendMessage;

public class MessageResponse
{
    [JsonProperty("status")]
    public int? Status { get; set; }

    [JsonProperty("status_message")]
    public string? StatusMessage { get; set; }

    [JsonProperty("message_token")]
    public long? MessageToken { get; set; }

    [JsonProperty("chat_hostname")]
    public string? ChatHostname { get; set; }

    [JsonProperty("billing_status")]
    public int? BillingStatus { get; set; }
}