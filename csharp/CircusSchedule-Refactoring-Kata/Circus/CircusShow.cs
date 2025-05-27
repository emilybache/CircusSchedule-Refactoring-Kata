using System.Collections.ObjectModel;
using Circus.ForFrontEnd;

namespace Circus;

public class CircusShow : IShow
{
    private readonly string _parentId;
    private readonly string _showId;
    private readonly string[] _childIds;
    private readonly bool _isShow;
    public string Id { get; }
    public string Name { get; }
    public int PlannedMinutes { get; internal set; }
    public int AssignedMinutes { get; internal set; }
    
    public CircusShow(string id, string name, int plannedMinutes, int assignedMinutes, string parentId, string showId,
        string[] childIds, bool isShow)
    {
        Id = id;
        Name = name;
        PlannedMinutes = plannedMinutes;
        AssignedMinutes = assignedMinutes;
        _parentId = parentId;
        _showId = showId;
        _childIds = childIds;
        _isShow = isShow;
    }
    
}