using Circus.ForFrontEnd;
using Circus.Legacy;

namespace Circus;

/**
 * imagine this is used by the front end to get data to display
 */
public class ShowServices
{
    private readonly LegacyRecord _show;
    private readonly LegacyUtil _legacyUtil;
    private LegacyConverter _converter;

    public ShowServices(LegacyRecord show, LegacyUtil legacyUtil)
    {
        _show = show;
        _legacyUtil = legacyUtil;
        _converter = new LegacyConverter(_legacyUtil);
    }
    
    public IAct GetAct(string showPartId, string actId)
    {
        // TODO: implement this
        throw new NotImplementedException();
    }
    public LegacyRecord? FindAct(string showPartId, string actId)
    {
        var children = _show.children;
        var cCount = children.Count();
        for (int i = 0; i < cCount; i++)
        {
            var showPart = children.Item(i);
            if (showPart.id == actId)
            {
                return showPart;
            }

            if (showPart.id == showPartId)
            {
                var acts = showPart.children;
                var sCount = acts.Count();
                for (int j = 0; j < sCount; j++)
                {
                    var act = acts.Item(j);
                    if (act.id == actId)
                    {
                        return act;
                    }
                }
            }
        }

        return null;
    }
}