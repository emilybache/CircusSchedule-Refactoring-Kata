using Circus.ForFrontEnd;
using Circus.Legacy;

namespace Circus;

public class LegacyConverter
{
    public LegacyUtil LegacyUtil { get; }

    public LegacyConverter(LegacyUtil legacyUtil)
    {
        LegacyUtil = legacyUtil;
    }

    public List<IPerformance> Convert(LegacyRecordList records)
    {
        var items = new List<IPerformance>();
        for (int i = 0; i < records.Count(); i++)
        {
            var record = records.Item(i);
            HandleSubItem(record, "", record.id, items);
        }

        return items;
    }

    private IPerformance HandleSubItem(LegacyRecord record, string parentId, string showId, List<IPerformance> items)
    {
        if (record.type == "Act")
        {
            IAct act = ConvertAct(record, parentId, showId);
            items.Add(act);
            return act;
        }
        else
        {
            var actId = record.id;
            var plannedMinutes = 0;
            var assignedMinutes = 0;
            var children = record.children;
            var childCount = children.Count();
            var childIds = new string[childCount];
            for (int i = 0; i < childCount; i++)
            {
                var child = children.Item(i);
                var performance = HandleSubItem(child, actId, showId, items);
                plannedMinutes += performance.PlannedMinutes;
                assignedMinutes += performance.AssignedMinutes;
                childIds[i] = performance.Id;
            }

            var act = ConvertCircusShow(record, parentId, showId, childIds, plannedMinutes, assignedMinutes);
            items.Add(act);
            return act;
        }
    }

    private IShow ConvertCircusShow(LegacyRecord record, string parentId, string showId, string[] childIds, int plannedMinutes,
        int assignedMinutes)
    {
        var act = new CircusShow(
            record.id,
            record.name,
            plannedMinutes,
            assignedMinutes,
            parentId,
            showId,
            childIds,
            record.type == "Show"
        );
        return act;
    }

    private IAct ConvertAct(LegacyRecord record, string parentId, string showId)
    {
        var performer = new Act(
            record.id,
            record.name,
            parentId,
            showId,
            LegacyUtil.PlannedMinutes(record),
            LegacyUtil.AssignedMinutes(record)
        );
        return performer;
    }

    public IArtist ConvertArtist(LegacyRecord record)
    {
        var skills = LegacyUtil.Skills(record);
        var artist = new Artist(
            record.id,
            record.name,
            skills);

        return artist;
    }
}