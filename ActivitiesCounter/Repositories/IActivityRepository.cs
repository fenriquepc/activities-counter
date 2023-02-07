using ActivitiesCounter.Entities;

namespace ActivitiesCounter.Repositories
{
    public interface IActivityRepository
    {
		ValueTask<IEnumerable<Activity>> GetAll();
        ValueTask RemoveAll();
        Task UpsertActivity(Activity activity);
    }
}