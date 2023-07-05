using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionResponse : Response
{
	[JsonProperty("disruption")]
	public Disruption? Disruption { get; set; }
}