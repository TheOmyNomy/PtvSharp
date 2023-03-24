using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RunResponse : Response
{
	[JsonProperty("run", DefaultValueHandling = DefaultValueHandling.Ignore)]
	public Run? Run { get; set; }
}