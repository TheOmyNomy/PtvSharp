using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionDirection
{
	[JsonProperty("route_direction_id")]
	public int? RouteDirectionId { get; set; }

	[JsonProperty("direction_id")]
	public int? Id { get; set; }

	[JsonProperty("direction_name")]
	public string? Name { get; set; }

	[JsonProperty("service_time")]
	public string? ServiceTime { get; set; }
}