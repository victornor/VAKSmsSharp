using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace VakSMSSharp.Entities;

public class Phone
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("tel")] public string Number { get; set; }
}