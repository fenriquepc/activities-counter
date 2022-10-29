namespace ActivitiesCounter.Entities
{
    public class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Game Game { get; set; }
        public DateTime Date { get; set; }
        public int Players { get; set; }
        public ActivityType Type { get; set; }
        public ActivityLevel Level { get; set; }
        public Organizer Organizer { get; set; }
    }
}
