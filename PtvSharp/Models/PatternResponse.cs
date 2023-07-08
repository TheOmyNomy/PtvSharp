using Newtonsoft.Json;

namespace PtvSharp.Models;

public class PatternResponse : Response
{
	[JsonProperty("disruptions")]
	public Disruption[]? Disruptions { get; set; }

	[JsonProperty("departures")]
	public PatternDeparture[]? Departures { get; set; }

	// TODO: Create model class for stops object
	[JsonProperty("stops")]
	public object? Stops { get; set; }

	// TODO: Create model class for routes object
	[JsonProperty("routes")]
	public object? Routes { get; set; }

	// TODO: Create model class for runs object
	[JsonProperty("runs")]
	public object? Runs { get; set; }

	// TODO: Create model class for directions object
	[JsonProperty("directions")]
	public object? Directions { get; set; }
}