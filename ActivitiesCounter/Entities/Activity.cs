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
	public List<string> Participants { get; set; } = new();
	public int AvailableCapacity => Capacity - Participants.Count;
	public ActivityType Type { get; set; }
	public ActivityLevel Level { get; set; }
	public Organizer Organizer { get; set; }
	public bool AdultsOnly { get; set; }
	public bool AllowPreinscription { get; set; }

	public void AddParticipant(string participant)
	{
		Participants.Add(participant);
	}
}
