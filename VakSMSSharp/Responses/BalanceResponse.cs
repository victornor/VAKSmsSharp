using Newtonsoft.Json;

namespace VakSMSSharp.Responses;

public class BalanceResponse
{
    [JsonProperty("balance")] public float Balance { get; set; }
}