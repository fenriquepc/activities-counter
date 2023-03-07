using ActivitiesCounter.Entities;
using Blazored.LocalStorage;

namespace ActivitiesCounter.Repositories;

public class ActivityRepository
{
	private const string ACTIVITIES_KEY = "activities";
	private readonly ILocalStorageService _localStorage;

	public ActivityRepository(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	public ValueTask<bool> ExistAny() =>
		_localStorage.ContainKeyAsync(ACTIVITIES_KEY);

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

		if (existingActivityIndex < 0)
		{
			activities.Add(activity);
		}
		else 
			activities[existingActivityIndex] = activity;

		await PersistActivities(activities);
	}

	public ValueTask BulkActivities(IEnumerable<Activity> activities) => 
		PersistActivities(activities);

	public async Task RemoveActivity(Guid id)
	{
		var activities = (await GetAll()).ToList();

		if (activities is null || !activities.Any())
			return;

		activities.RemoveAll(a => a.Id == id);
		await PersistActivities(activities);
	}

	private ValueTask PersistActivities(IEnumerable<Activity> activities)
		=> _localStorage.SetItemAsync(ACTIVITIES_KEY, activities);
}
