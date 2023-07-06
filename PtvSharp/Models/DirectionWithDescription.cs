using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DirectionWithDescription
{
	[JsonProperty("route_direction_description")]
	public string? RouteDirectionDescription { get; set; }

	[JsonProperty("direction_id")]
	public int? Id { get; set; }

	[JsonProperty("direction_name")]
	public string? Name { get; set; }

	[JsonProperty("route_id")]
	public int? RouteId { get; set; }

	[JsonProperty("route_type")]
	public int? RouteType { get; set; }
}