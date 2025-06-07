using System.Collections.ObjectModel;
using Circus.ForFrontEnd;

namespace Circus;

public class Act : IAct
{
    private readonly string _actId;
    private readonly string _showId;
    public string Id { get; internal set; }
    public string Name { get; }
    public int PlannedMinutes { get; }

    public Skill ActSkill { get; }
    
    public Act(string id, string name, string actId, string showId, int plannedMinutes, Skill skill)
    {
        Id = id;
        Name = name;
        _actId = actId;
        _showId = showId;
        PlannedMinutes = plannedMinutes;
        ActSkill = skill;
    }

}