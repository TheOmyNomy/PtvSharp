using Newtonsoft.Json;

namespace PtvSharp.Models;

public class StopStaffing
{
	[JsonProperty("fri_am_from")]
	public string? FriAmFrom { get; set; }
	
	[JsonProperty("fri_am_to")]
	public string? FriAmTo { get; set; }
	
	[JsonProperty("fri_pm_from")]
	public string? FriPmFrom { get; set; }
	
	[JsonProperty("fri_pm_to")]
	public string? FriPmTo { get; set; }
	
	[JsonProperty("mon_am_from")]
	public string? MonAmFrom { get; set; }
	
	[JsonProperty("mon_am_to")]
	public string? MonAmTo { get; set; }
	
	[JsonProperty("mon_pm_from")]
	public string? MonPmFrom { get; set; }
	
	[JsonProperty("mon_pm_to")]
	public string? MonPmTo { get; set; }
	
	[JsonProperty("ph_additional_text")]
	public string? PhAdditionalText { get; set; }
	
	[JsonProperty("ph_from")]
	public string? PhFrom { get; set; }
	
	[JsonProperty("ph_to")]
	public string? PhTo { get; set; }
	
	[JsonProperty("sat_am_from")]
	public string? SatAmFrom { get; set; }
	
	[JsonProperty("sat_am_to")]
	public string? SatAmTo { get; set; }
	
	[JsonProperty("sat_pm_from")]
	public string? SatPmFrom { get; set; }
	
	[JsonProperty("sat_pm_to")]
	public string? SatPmTo { get; set; }
	
	[JsonProperty("thu_am_from")]
	public string? ThuAmFrom { get; set; }
	
	[JsonProperty("thu_am_to")]
	public string? ThuAmTo { get; set; }
	
	[JsonProperty("thu_pm_from")]
	public string? ThuPmFrom { get; set; }
	
	[JsonProperty("thu_pm_to")]
	public string? ThuPmTo { get; set; }
	
	[JsonProperty("tue_am_from")]
	public string? TueAmFrom { get; set; }
	
	[JsonProperty("tue_am_to")]
	public string? TueAmTo { get; set; }
	
	[JsonProperty("tue_pm_from")]
	public string? TuePmFrom { get; set; }
	
	[JsonProperty("tue_pm_to")]
	public string? TuePmTo { get; set; }
	
	[JsonProperty("wed_am_from")]
	public string? WedAmFrom { get; set; }
	
	[JsonProperty("wed_am_to")]
	public string? WedAmTo { get; set; }
	
	[JsonProperty("wed_pm_from")]
	public string? WedPmFrom { get; set; }
	
	[JsonProperty("wed_pm_to")]
	public string? WedPmTo { get; set; }
}