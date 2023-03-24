using Newtonsoft.Json;

namespace PtvSharp.Models;

public class RunsResponse : Response
{
	[JsonProperty("runs", DefaultValueHandling = DefaultValueHandling.Ignore)]
	public Run[]? Runs { get; set; }
}