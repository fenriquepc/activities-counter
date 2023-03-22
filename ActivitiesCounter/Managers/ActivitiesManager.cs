using ActivitiesCounter.Entities;
using ActivitiesCounter.Repositories;

namespace ActivitiesCounter.Managers;

public class ActivitiesManager
{
	private readonly FilesManager _filesManager;
    private readonly ActivityRepository _activityRepository;
	private readonly bool _showAll;
	private const int ActivityOvertimeMinutes = 30;

	public ActivitiesManager(ActivityRepository activityRepository, FilesManager filesManager, IConfiguration configuration)
	{
		_activityRepository = activityRepository;
		_filesManager = filesManager;
		_showAll = bool.Parse(configuration["showAll"]);
    }

	public async Task BulkActivitiesFromFiles(bool resetExistingActivities = false)
	{
		var existActivities = await _activityRepository.ExistAny();
		if (existActivities && !resetExistingActivities) 
			return;

		var activitiesFromFiles = await _filesManager.GetActivitiesFromFiles();

		if (_showAll)
			activitiesFromFiles.ToList().ForEach(a => a.AllowPreinscription = true);

		await _activityRepository.BulkActivities(activitiesFromFiles);
	}

	public ValueTask<IEnumerable<Activity>> GetAll() => 
		_activityRepository.Get();

	public async Task<IEnumerable<Activity>> GetNextActivitiesAsync()
	{
		if (_showAll)
			return await _activityRepository.GetAll();

		var now = DateTime.Now;
		var activities = await _activityRepository.Get(from: now.AddMinutes(-ActivityOvertimeMinutes), to: now.Date.AddDays(1));
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
