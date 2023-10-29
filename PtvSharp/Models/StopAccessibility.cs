using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopAccessibility
{
	[JsonProperty("lighting")]
	public bool? Lighting { get; set; }

	[JsonProperty("platform_number")]
	public int? PlatformNumber { get; set; }

	[JsonProperty("audio_customer_information")]
	public bool? AudioCustomerInformation { get; set; }

	[JsonProperty("escalator")]
	public bool? Escalator { get; set; }

	[JsonProperty("hearing_loop")]
	public bool? HearingLoop { get; set; }

	[JsonProperty("lift")]
	public bool? Lift { get; set; }

	[JsonProperty("stairs")]
	public bool? Stairs { get; set; }

	[JsonProperty("stop_accessible")]
	public bool? StopAccessible { get; set; }

	[JsonProperty("tactile_ground_surface_indicator")]
	public bool? TactileGroundSurfaceIndicator { get; set; }

	[JsonProperty("waiting_room")]
	public bool? WaitingRoom { get; set; }

	[JsonProperty("wheelchair")]
	public StopAccessibilityWheelchair? Wheelchair { get; set; }
}