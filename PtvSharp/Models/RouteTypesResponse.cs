using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RouteTypesResponse : Response
{
	[JsonProperty("route_types")]
	public RouteType[]? RouteTypes { get; set; }
}