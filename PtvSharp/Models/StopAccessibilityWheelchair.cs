using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopAccessibilityWheelchair
{
	[JsonProperty("accessible_ramp")]
	public bool? AccessibleRamp { get; set; }

	[JsonProperty("parking")]
	public bool? Parking { get; set; }

	[JsonProperty("telephone")]
	public bool? Telephone { get; set; }

	[JsonProperty("toilet")]
	public bool? Toilet { get; set; }

	[JsonProperty("low_ticket_counter")]
	public bool? LowTicketCounter { get; set; }

	[JsonProperty("manouvering")]
	public bool? Manouvering { get; set; }

	[JsonProperty("raised_platform")]
	public bool? RaisedPlatform { get; set; }

	[JsonProperty("ramp")]
	public bool? Ramp { get; set; }

	[JsonProperty("secondary_path")]
	public bool? SecondaryPath { get; set; }

	[JsonProperty("raised_platform_shelther")]
	public bool? RaisedPlatformShelther { get; set; }

	[JsonProperty("steep_ramp")]
	public bool? SteepRamp { get; set; }
}