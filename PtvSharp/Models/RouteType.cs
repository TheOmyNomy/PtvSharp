using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RouteType
{
	[JsonProperty("route_type_name")]
	public string? Name { get; set; }

	[JsonProperty("route_type")]
	public int? Id { get; set; }
}