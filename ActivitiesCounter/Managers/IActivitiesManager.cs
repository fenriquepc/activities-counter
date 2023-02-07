using ActivitiesCounter.Entities;

namespace ActivitiesCounter.Managers
{
	public interface IActivitiesManager
	{
		Task UpsertActivity(Activity activity);
		Task AddParticipant(Activity activity, string participant);
		Task<IEnumerable<Activity>> GetNextActivitiesAsync();
	}
}