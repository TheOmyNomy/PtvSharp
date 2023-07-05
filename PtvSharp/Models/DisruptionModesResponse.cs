using Newtonsoft.Json;

namespace PtvSharp.Models;

public class DisruptionModesResponse : Response
{
	[JsonProperty("disruption_modes")]
	public DisruptionMode[]? Modes { get; set; }
}