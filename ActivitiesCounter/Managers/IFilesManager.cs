namespace ActivitiesCounter.Managers
{
    public interface IFilesManager
    {
        Task LoadFilesData(bool reset = false);
    }
}