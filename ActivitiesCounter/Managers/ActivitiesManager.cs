using ActivitiesCounter.Entities;
using ActivitiesCounter.Repositories;

namespace ActivitiesCounter.Managers
{
    public class ActivitiesManager : IActivitiesManager
    {
        private readonly IActivityRepository _activityRepository;

        public ActivitiesManager(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<Activity>> GetNextActivitiesAsync()
        {
            var activities = await _activityRepository.GetAll();
            return activities.OrderByDescending(a => a.Date);
        }

        public Task UpsertActivity(Activity activity) 
            => _activityRepository.UpsertActivity(activity);

        public async Task AddParticipant(Activity activity, string participant)
        {
            activity.AddParticipant(participant);
            await _activityRepository.UpsertActivity(activity);
        }
    }
}
