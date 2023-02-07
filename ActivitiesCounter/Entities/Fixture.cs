namespace ActivitiesCounter.Entities
{
    public class Fixture
    {
        /// <summary>
        /// Activity
        /// </summary>
        public Activity Activity { get; set; }

        /// <summary>
        /// Date of the activity
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Max number of participants
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Capacity reserved
        /// </summary>
        public int Occuped { get; set; }
    }
}
