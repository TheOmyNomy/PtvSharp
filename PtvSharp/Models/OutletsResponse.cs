using Newtonsoft.Json;

namespace PtvSharp.Models;

public class OutletsResponse : Response
{
	[JsonProperty("outlets")]
	public Outlet[]? Outlets { get; set; }
}