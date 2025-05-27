namespace Circus.ForFrontEnd;

public interface IPerformance
{
    int PlannedMinutes { get; }
    int AssignedMinutes { get; }
    string Id { get; }
}