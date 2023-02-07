using ActivitiesCounter.Entities;
using Blazored.LocalStorage;

namespace ActivitiesCounter.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private const string ACTIVITIES_KEY = "activities";
        private readonly ILocalStorageService _localStorage;

        public ActivityRepository(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async ValueTask<IEnumerable<Activity>> GetAll()
        {
            var result = await _localStorage.GetItemAsync<IEnumerable<Activity>>(ACTIVITIES_KEY); 
            return result ?? Enumerable.Empty<Activity>();
        }

        public ValueTask RemoveAll()
            => _localStorage.RemoveItemAsync(ACTIVITIES_KEY);

        public async Task UpsertActivity(Activity activity)
        {
            var activities = (await GetAll()).ToList() ?? new List<Activity>();
            var existingActivityIndex = activities.FindIndex(a => a.Id == activity.Id);

            if (existingActivityIndex < 0) activities.Add(activity);
            else activities[existingActivityIndex] = activity;

            await PersistActivities(activities);
        }

        private ValueTask PersistActivities(IEnumerable<Activity> activities)
            => _localStorage.SetItemAsync(ACTIVITIES_KEY, activities);
    }
}
