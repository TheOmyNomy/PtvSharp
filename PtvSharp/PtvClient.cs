using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using PtvSharp.Models;

namespace PtvSharp;

public class PtvClient
{
	private const string BaseUrl = "https://timetableapi.ptv.vic.gov.au";

	private const string VersionEndpoint = "/v3";

	private const string OutletsEndpoint = VersionEndpoint + "/outlets";
	private const string OutletsByLocationEndpoint = VersionEndpoint + "/outlets/location/{0},{1}";

	private const string RouteTypesEndpoint = VersionEndpoint + "/route_types";

	private const string RoutesEndpoint = VersionEndpoint + "/routes";
	private const string RoutesByRouteEndpoint = VersionEndpoint + "/routes/{0}";

	private const string RunsByRouteEndpoint = VersionEndpoint + "/runs/route/{0}";
	private const string RunsByRouteByRouteTypeEndpoint = VersionEndpoint + "/runs/route/{0}/route_type/{1}";
	private const string RunsEndpoint = VersionEndpoint + "/runs/{0}";
	private const string RunsByRouteTypeEndpoint = VersionEndpoint + "/runs/{0}/route_type/{1}";

	private const string SearchEndpoint = VersionEndpoint + "/search/{0}";

	private const string DisruptionsEndpoint = VersionEndpoint + "/disruptions";
	private const string DisruptionsByRouteEndpoint = VersionEndpoint + "/disruptions/route/{0}";
	private const string DisruptionsByRouteByStopEndpoint = VersionEndpoint + "/disruptions/route/{0}/stop/{1}";
	private const string DisruptionsByStopEndpoint = VersionEndpoint + "/disruptions/stop/{0}";
	private const string DisruptionsByDisruptionEndpoint = VersionEndpoint + "/disruptions/{0}";
	private const string DisruptionsModesEndpoint = VersionEndpoint + "/disruptions/modes";

	private static readonly HttpClient Client = new()
	{
		BaseAddress = new Uri(BaseUrl)
	};

	private readonly int _developerId;
	private readonly string _developerKey;

	public PtvClient(int developerId, string developerKey)
	{
		_developerId = developerId;
		_developerKey = developerKey;
	}

	public async Task<DisruptionsResponse?> GetDisruptionsAsync(int[]? routeTypes = null, int[]? disruptionModes = null, string? disruptionStatus = null)
	{
		string endpoint = ConstructEndpoint(DisruptionsEndpoint);
		List<Parameter> parameters = new List<Parameter>();

		if (routeTypes != null)
		{
			foreach (int routeType in routeTypes)
				parameters.Add(Parameter.Create("route_types", routeType));
		}

		if (disruptionModes != null)
		{
			foreach (int disruptionMode in disruptionModes)
				parameters.Add(Parameter.Create("disruption_modes", disruptionMode));
		}

		if (!string.IsNullOrWhiteSpace(disruptionStatus))
			parameters.Add(Parameter.Create("disruption_status", disruptionStatus));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<DisruptionsResponse>(url);
	}

	public async Task<DisruptionsResponse?> GetDisruptionsByRouteAsync(int routeId, string? disruptionStatus = null)
	{
		string endpoint = ConstructEndpoint(DisruptionsByRouteEndpoint, routeId);
		List<Parameter> parameters = new List<Parameter>();

		if (!string.IsNullOrWhiteSpace(disruptionStatus))
			parameters.Add(Parameter.Create("disruption_status", disruptionStatus));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<DisruptionsResponse>(url);
	}

	public async Task<DisruptionsResponse?> GetDisruptionsAsync(int routeId, int stopId, string? disruptionStatus = null)
	{
		string endpoint = ConstructEndpoint(DisruptionsByRouteByStopEndpoint, routeId, stopId);
		List<Parameter> parameters = new List<Parameter>();

		if (!string.IsNullOrWhiteSpace(disruptionStatus))
			parameters.Add(Parameter.Create("disruption_status", disruptionStatus));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<DisruptionsResponse>(url);
	}

	public async Task<DisruptionsResponse?> GetDisruptionsByStopAsync(int stopId, string? disruptionStatus = null)
	{
		string endpoint = ConstructEndpoint(DisruptionsByStopEndpoint, stopId);
		List<Parameter> parameters = new List<Parameter>();

		if (!string.IsNullOrWhiteSpace(disruptionStatus))
			parameters.Add(Parameter.Create("disruption_status", disruptionStatus));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<DisruptionsResponse>(url);
	}

	public async Task<DisruptionResponse?> GetDisruptionAsync(int disruptionId)
	{
		string endpoint = ConstructEndpoint(DisruptionsByDisruptionEndpoint, disruptionId);

		string url = ConstructUrl(endpoint);
		return await GetAsync<DisruptionResponse>(url);
	}

	public async Task<DisruptionModesResponse?> GetDisruptionModesAsync()
	{
		string endpoint = ConstructEndpoint(DisruptionsModesEndpoint);

		string url = ConstructUrl(endpoint);
		return await GetAsync<DisruptionModesResponse>(url);
	}

	public async Task<OutletsResponse?> GetOutletsAsync(int? maxResults = null)
	{
		string endpoint = ConstructEndpoint(OutletsEndpoint);
		List<Parameter> parameters = new List<Parameter>();

		if (maxResults.HasValue)
			parameters.Add(Parameter.Create("max_results", maxResults.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<OutletsResponse>(url);
	}

	public async Task<OutletsResponse?> GetOutletsAsync(float latitude, float longitude, double? maxDistance = null, int? maxResults = null)
	{
		string endpoint = ConstructEndpoint(OutletsByLocationEndpoint, latitude, longitude);
		List<Parameter> parameters = new List<Parameter>();

		if (maxDistance.HasValue)
			parameters.Add(Parameter.Create("max_distance", maxDistance.Value));

		if (maxResults.HasValue)
			parameters.Add(Parameter.Create("max_results", maxResults.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<OutletsResponse>(url);
	}

	public async Task<RouteTypesResponse?> GetRouteTypesAsync()
	{
		string endpoint = ConstructEndpoint(RouteTypesEndpoint);
		string url = ConstructUrl(endpoint);

		return await GetAsync<RouteTypesResponse>(url);
	}

	public async Task<RoutesResponse?> GetRoutesAsync(int[]? routeTypes = null, string? routeName = null)
	{
		string endpoint = ConstructEndpoint(RoutesEndpoint);
		List<Parameter> parameters = new List<Parameter>();

		if (routeTypes != null)
		{
			foreach (int routeType in routeTypes)
				parameters.Add(Parameter.Create("route_types", routeType));
		}

		if (!string.IsNullOrWhiteSpace(routeName))
			parameters.Add(Parameter.Create("route_name", routeName));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<RoutesResponse>(url);
	}

	public async Task<RouteResponse?> GetRouteAsync(int routeId, bool? includeGeopath = null, DateTime? geopathUtc = null)
	{
		string endpoint = ConstructEndpoint(RoutesByRouteEndpoint, routeId);
		List<Parameter> parameters = new List<Parameter>();

		if (includeGeopath.HasValue)
			parameters.Add(Parameter.Create("include_geopath", includeGeopath.Value));

		if (geopathUtc.HasValue)
			parameters.Add(Parameter.Create("geopath_utc", geopathUtc.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<RouteResponse>(url);
	}

	public async Task<RunsResponse?> GetRunsAsync(int routeId, string[]? expand = null, DateTime? dateUtc = null)
	{
		string endpoint = ConstructEndpoint(RunsByRouteEndpoint, routeId);
		List<Parameter> parameters = new List<Parameter>();

		if (expand != null)
		{
			foreach (string value in expand)
				parameters.Add(Parameter.Create("expand", value));
		}

		if (dateUtc.HasValue)
			parameters.Add(Parameter.Create("date_utc", dateUtc.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<RunsResponse>(url);
	}

	public async Task<RunsResponse?> GetRunsAsync(int routeId, int routeType, string[]? expand = null, DateTime? dateUtc = null)
	{
		string endpoint = ConstructEndpoint(RunsByRouteByRouteTypeEndpoint, routeId, routeType);
		List<Parameter> parameters = new List<Parameter>();

		if (expand != null)
		{
			foreach (string value in expand)
				parameters.Add(Parameter.Create("expand", value));
		}

		if (dateUtc.HasValue)
			parameters.Add(Parameter.Create("date_utc", dateUtc.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<RunsResponse>(url);
	}

	public async Task<RunsResponse?> GetRunsAsync(string runRef, string[]? expand = null, DateTime? dateUtc = null, bool? includeGeopath = null)
	{
		string endpoint = ConstructEndpoint(RunsEndpoint, runRef);
		List<Parameter> parameters = new List<Parameter>();

		if (expand != null)
		{
			foreach (string value in expand)
				parameters.Add(Parameter.Create("expand", value));
		}

		if (dateUtc.HasValue)
			parameters.Add(Parameter.Create("date_utc", dateUtc.Value));

		if (includeGeopath.HasValue)
			parameters.Add(Parameter.Create("include_geopath", includeGeopath.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<RunsResponse>(url);
	}

	public async Task<RunResponse?> GetRunAsync(string runRef, int routeType, string[]? expand = null, DateTime? dateUtc = null, bool? includeGeopath = null)
	{
		string endpoint = ConstructEndpoint(RunsByRouteTypeEndpoint, runRef, routeType);
		List<Parameter> parameters = new List<Parameter>();

		if (expand != null)
		{
			foreach (string value in expand)
				parameters.Add(Parameter.Create("expand", value));
		}

		if (dateUtc.HasValue)
			parameters.Add(Parameter.Create("date_utc", dateUtc.Value));

		if (includeGeopath.HasValue)
			parameters.Add(Parameter.Create("include_geopath", includeGeopath.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<RunResponse>(url);
	}

	public async Task<SearchResponse?> GetSearchAsync(string term, int[]? routeTypes = null, float? latitude = null, float? longitude = null, float? maxDistance = null,
		bool? includeOutlets = null, bool? matchStopBySuburb = null, bool? matchRouteBySuburb = null, bool? matchStopByGtfsStopId = null)
	{
		string endpoint = ConstructEndpoint(SearchEndpoint, term);
		List<Parameter> parameters = new List<Parameter>();

		if (routeTypes != null)
		{
			foreach (int routeType in routeTypes)
				parameters.Add(Parameter.Create("route_types", routeType));
		}

		if (latitude.HasValue)
			parameters.Add(Parameter.Create("latitude", latitude.Value));

		if (longitude.HasValue)
			parameters.Add(Parameter.Create("longitude", longitude.Value));

		if (maxDistance.HasValue)
			parameters.Add(Parameter.Create("max_distance", maxDistance.Value));

		if (includeOutlets.HasValue)
			parameters.Add(Parameter.Create("include_outlets", includeOutlets.Value));

		if (matchStopBySuburb.HasValue)
			parameters.Add(Parameter.Create("match_stop_by_suburb", matchStopBySuburb.Value));

		if (matchRouteBySuburb.HasValue)
			parameters.Add(Parameter.Create("match_route_by_suburb", matchRouteBySuburb.Value));

		if (matchStopByGtfsStopId.HasValue)
			parameters.Add(Parameter.Create("match_stop_by_gtfs_stop_id", matchStopByGtfsStopId.Value));

		string url = ConstructUrl(endpoint, parameters);
		return await GetAsync<SearchResponse>(url);
	}

	private async Task<T?> GetAsync<T>(string url) where T : Response
	{
		using HttpResponseMessage responseMessage = await Client.GetAsync(url);
		string contents = await responseMessage.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<T>(contents);
	}

	private string ConstructEndpoint(string endpoint, params object[] arguments)
	{
		for (int i = 0; i < arguments.Length; i++)
		{
			if (arguments[i] is string value && !string.IsNullOrWhiteSpace(value))
				arguments[i] = Uri.EscapeDataString(value);
		}

		return string.Format(endpoint, arguments);
	}

	private string ConstructUrl(string endpoint, List<Parameter>? parameters = null)
	{
		StringBuilder urlBuilder = new StringBuilder(endpoint);
		urlBuilder.Append("?devid=").Append(_developerId);

		if (parameters != null)
		{
			foreach (var parameter in parameters)
			{
				urlBuilder.Append("&").Append(parameter.Name).Append("=");

				string value = Uri.EscapeDataString(parameter.Value.ToString()!);
				urlBuilder.Append(value);
			}
		}

		byte[] keyBytes = Encoding.ASCII.GetBytes(_developerKey);

		string url = urlBuilder.ToString();
		byte[] urlBytes = Encoding.ASCII.GetBytes(url);

		byte[] tokenBytes = new HMACSHA1(keyBytes).ComputeHash(urlBytes);

		StringBuilder signatureBuilder = new StringBuilder();

		Array.ForEach(tokenBytes, tokenByte =>
		{
			string value = tokenByte.ToString("X2");
			signatureBuilder.Append(value);
		});

		string signature = signatureBuilder.ToString();
		urlBuilder.Append("&signature=").Append(signature);

		return urlBuilder.ToString();
	}
}