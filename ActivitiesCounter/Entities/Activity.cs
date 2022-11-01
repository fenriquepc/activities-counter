namespace ActivitiesCounter.Entities
{
    public class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Game Game { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public int Reserved { get; set; }
        public int AvailableCapacity { get=> Capacity - Reserved; }
        public ActivityType Type { get; set; }
        public ActivityLevel Level { get; set; }
        public Organizer Organizer { get; set; }
    }
}
