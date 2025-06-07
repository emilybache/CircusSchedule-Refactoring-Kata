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
            HandleShowPart(record, "", record.id, items);
        }

        return items;
    }

    private IPerformance HandleShowPart(LegacyRecord record, string parentId, string showId, List<IPerformance> items)
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
            var children = record.children;
            var childCount = children.Count();
            var childIds = new string[childCount];
            for (int i = 0; i < childCount; i++)
            {
                var child = children.Item(i);
                var performance = HandleShowPart(child, actId, showId, items);
                plannedMinutes += performance.PlannedMinutes;
                childIds[i] = performance.Id;
            }

            var act = ConvertCircusShow(record, parentId, showId, childIds, plannedMinutes);
            items.Add(act);
            return act;
        }
    }

    private IShow ConvertCircusShow(LegacyRecord record, string parentId, string showId, string[] childIds, int plannedMinutes)
    {
        var act = new CircusShow(
            record.id,
            record.name,
            plannedMinutes,
            parentId,
            showId,
            childIds,
            record.type == "Show"
        );
        return act;
    }

    public IAct ConvertAct(LegacyRecord record, string parentId, string showId)
    {
        var performer = new Act(
            record.id,
            record.name,
            parentId,
            showId,
            LegacyUtil.PlannedMinutes(record),
            LegacyUtil.Skills(record).FirstOrDefault(Skill.MC)
        );
        return performer;
    }
    
    

}