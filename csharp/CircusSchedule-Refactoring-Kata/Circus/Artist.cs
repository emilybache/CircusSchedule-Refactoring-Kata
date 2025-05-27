using System.Collections.ObjectModel;
using Circus.ForFrontEnd;

namespace Circus;

public class Artist : IArtist
{
    public string Id { get; }
    public string Name { get; }
    
    public List<Skill> Skills { get; internal set; }

    // could have Availablility here
    // IDictionary<long, IAvailability> Availability {get; set;}

    public Artist(string id, string name, List<Skill> skills)
    {
        Id = id;
        Name = name;
        Skills = skills;
    }
}