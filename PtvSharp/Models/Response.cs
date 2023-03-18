using Newtonsoft.Json;

namespace PtvSharp.Models;

public class Response
{
	[JsonProperty("message", DefaultValueHandling = DefaultValueHandling.Ignore)]
	public string? Message { get; set; }

	[JsonProperty("status")]
	public Status? Status { get; set; }
}