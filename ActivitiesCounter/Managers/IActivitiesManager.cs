using ActivitiesCounter.Entities;

namespace ActivitiesCounter.Managers
{
	public interface IActivitiesManager
	{
		Task UpsertActivityAsync(Activity activity);
		Task AddParticipantAsync(Activity activity, string participant);
		Task<IEnumerable<Activity>> GetNextActivitiesAsync();
	}
}