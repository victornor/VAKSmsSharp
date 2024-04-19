using Newtonsoft.Json;

namespace VakSMSSharp.Responses;

public class GetSmsResponse
{
    [JsonProperty("smsCode")] public string SmsCode { get; set; }
}