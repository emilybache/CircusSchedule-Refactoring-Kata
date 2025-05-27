using System.Collections.ObjectModel;
using Circus.ForFrontEnd;

namespace Circus;

/**
 * This is a placeholder for an Artist or several Artists within a CircusAct
 */
public class Act : IAct
{
    private readonly string _actId;
    private readonly string _showId;
    public string Id { get; internal set; }
    public string Name { get; }
    public int PlannedMinutes { get; }
    public int AssignedMinutes { get; }

    public Act(string id, string name, string actId, string showId, int plannedMinutes, int assignedMinutes)
    {
        Id = id;
        Name = name;
        _actId = actId;
        _showId = showId;
        PlannedMinutes = plannedMinutes;
        AssignedMinutes = assignedMinutes;
    }
}