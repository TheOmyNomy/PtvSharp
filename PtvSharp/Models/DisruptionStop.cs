using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionStop
{
	[JsonProperty("stop_id")]
	public int? Id { get; set; }

	[JsonProperty("stop_name")]
	public string? Name { get; set; }
}