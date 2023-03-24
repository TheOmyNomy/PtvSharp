using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RouteResponse : Response
{
	[JsonProperty("route")]
	public Route? Route { get; set; }
}