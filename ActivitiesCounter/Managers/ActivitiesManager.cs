using ActivitiesCounter.Entities;
using ActivitiesCounter.Repositories;

namespace ActivitiesCounter.Managers;

public class ActivitiesManager
{
	private readonly FilesManager _filesManager;
	private readonly ActivityRepository _activityRepository;

	public ActivitiesManager(ActivityRepository activityRepository, FilesManager filesManager)
	{
		_activityRepository = activityRepository;
		_filesManager = filesManager;
	}

	public async Task BulkActivitiesFromFiles(bool resetExistingActivities = false)
	{
		var existActivities = await _activityRepository.ExistAny();
		if (existActivities && !resetExistingActivities) 
			return;

		var activitiesFromFiles = await _filesManager.GetActivitiesFromFiles();
		await _activityRepository.BulkActivities(activitiesFromFiles);
	}

	public async Task<IEnumerable<Activity>> GetNextActivitiesAsync()
	{
		var activities = await _activityRepository.GetAll();
		return activities.OrderBy(a => a.Date);
	}

	public Task UpsertActivityAsync(Activity activity) 
		=> _activityRepository.UpsertActivity(activity);

	public Task AddParticipantAsync(Activity activity, string participant)
	{
		activity.AddParticipant(participant);
		return UpsertActivityAsync(activity);
	}

	public Task RemoveActivityAsync(Activity activity) => 
		_activityRepository.RemoveActivity(activity.Id);
}
