using Newtonsoft.Json;

namespace PtvSharp.Models;

public class Disruptions
{
	[JsonProperty("general")]
	public Disruption[]? General { get; set; }

	[JsonProperty("metro_train")]
	public Disruption[]? MetroTrain { get; set; }

	[JsonProperty("metro_tram")]
	public Disruption[]? MetroTram { get; set; }

	[JsonProperty("metro_bus")]
	public Disruption[]? MetroBus { get; set; }

	[JsonProperty("regional_train")]
	public Disruption[]? RegionalTrain { get; set; }

	[JsonProperty("regional_coach")]
	public Disruption[]? RegionalCoach { get; set; }

	[JsonProperty("regional_bus")]
	public Disruption[]? RegionalBus { get; set; }

	[JsonProperty("school_bus")]
	public Disruption[]? SchoolBus { get; set; }

	[JsonProperty("telebus")]
	public Disruption[]? Telebus { get; set; }

	[JsonProperty("night_bus")]
	public Disruption[]? NightBus { get; set; }

	[JsonProperty("ferry")]
	public Disruption[]? Ferry { get; set; }

	[JsonProperty("interstate_train")]
	public Disruption[]? InterstateTrain { get; set; }

	[JsonProperty("skybus")]
	public Disruption[]? Skybus { get; set; }

	[JsonProperty("taxi")]
	public Disruption[]? Taxi { get; set; }
}