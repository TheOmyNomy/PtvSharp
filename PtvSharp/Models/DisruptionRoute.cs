using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionRoute
{
	[JsonProperty("route_type")]
	public int? Type { get; set; }

	[JsonProperty("route_id")]
	public int? Id { get; set; }

	[JsonProperty("route_name")]
	public string? Name { get; set; }

	[JsonProperty("route_number")]
	public string? Number { get; set; }

	[JsonProperty("route_gtfs_id")]
	public string? GtfsId { get; set; }

	[JsonProperty("direction")]
	public DisruptionDirection? Direction { get; set; }
}