using ActivitiesCounter.Entities;
using ActivitiesCounter.Repositories;

namespace ActivitiesCounter.Managers;

public class ActivitiesManager
{
	private readonly ActivityRepository _activityRepository;

	public ActivitiesManager(ActivityRepository activityRepository)
	{
		_activityRepository = activityRepository;
	}

	public async Task<IEnumerable<Activity>> GetNextActivitiesAsync()
	{
		var activities = await _activityRepository.GetAll();
		return activities.OrderByDescending(a => a.Date);
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
