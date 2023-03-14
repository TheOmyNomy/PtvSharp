using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RouteTypesResponse
{
	[JsonProperty("route_types")]
	public RouteType[]? RouteTypes { get; set; }

	[JsonProperty("status")]
	public Status? Status { get; set; }
}