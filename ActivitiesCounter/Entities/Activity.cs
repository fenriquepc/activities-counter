using System.Text.Json.Serialization;

namespace ActivitiesCounter.Entities;

public class Activity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Game { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int Capacity { get; set; }
    public IEnumerable<string> Participants => _participants;
    public int AvailableCapacity => Capacity - _participants.Count;
    public ActivityType Type { get; set; }
    public ActivityLevel Level { get; set; }
    public Organizer Organizer { get; set; }
    public bool AdultsOnly { get; set; }
    public bool AllowPreinscription { get; set; }
    [JsonPropertyName("participants")] 
    private IList<string> _participants = new List<string>();

    public void AddParticipant(string participant)
    {
        _participants.Add(participant);
    }
}
