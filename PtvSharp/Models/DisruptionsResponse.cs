using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionsResponse : Response
{
	[JsonProperty("disruptions")]
	public Disruptions? Disruptions { get; set; }
}