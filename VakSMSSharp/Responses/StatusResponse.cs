using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VakSMSSharp.Enums;

namespace VakSMSSharp.Responses;

public class StatusResponse
{
    [JsonProperty("status")] 
    [JsonConverter(typeof(StringEnumConverter))]
    public PhoneStatus Status { get; set; }
}