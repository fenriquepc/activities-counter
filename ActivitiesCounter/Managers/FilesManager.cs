using ActivitiesCounter.Entities;
using ActivitiesCounter.Repositories;
using System.Net.Http.Json;

namespace ActivitiesCounter.Managers
{
	public class FilesManager
	{
		private const string ACTIVITIES_JSON = "data/activities.json";
		private readonly HttpClient _http;

		public FilesManager(HttpClient http, ActivityRepository activityRepository)
		{
			_http = http;
		}

		public Task<IEnumerable<Activity>> GetActivitiesFromFiles() => 
			_http.GetFromJsonAsync<IEnumerable<Activity>>($"{ACTIVITIES_JSON}?{Guid.NewGuid()}");
	}
}
