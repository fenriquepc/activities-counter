using ActivitiesCounter.Entities;
using ActivitiesCounter.Repositories;
using System.Net.Http.Json;

namespace ActivitiesCounter.Managers
{
    public class FilesManager : IFilesManager
    {
        private const string ACTIVITIES_JSON = "data/activities.json";
        private readonly HttpClient _http;
        private readonly IActivityRepository _activityRepository;

        public FilesManager(HttpClient http, IActivityRepository activityRepository)
        {
            _http = http;
            _activityRepository = activityRepository;
        }

        public async Task LoadFilesData(bool reset = false)
        {
            if (reset) await _activityRepository.RemoveAll();

            var existingActivities = await _activityRepository.GetAll();
            if (!existingActivities.Any())
                await LoadActivities();
        }

        private async Task LoadActivities()
        {
            var activities = await _http.GetFromJsonAsync<IEnumerable<Activity>>(ACTIVITIES_JSON);

            foreach (var activity in activities)
            {
                await _activityRepository.UpsertActivity(activity);
            }
        }
    }
}
