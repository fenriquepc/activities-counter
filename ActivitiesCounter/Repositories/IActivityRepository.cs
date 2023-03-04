using ActivitiesCounter.Entities;

namespace ActivitiesCounter.Repositories
{
    public interface IActivityRepository
    {
		ValueTask<IEnumerable<Activity>> GetAll();
        Task RemoveActivity(Guid id);
        ValueTask RemoveAll();
        Task UpsertActivity(Activity activity);
    }
}