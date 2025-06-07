using System.Collections.ObjectModel;
using Circus.ForFrontEnd;

namespace Circus.Legacy;

public class LegacyUtil
{
    private readonly LegacyRecordList _records;
    private readonly IEnumerable<LegacyRecordSpec> _specs;

    public LegacyUtil(LegacyRecordList records, IEnumerable<LegacyRecordSpec> specs)
    {
        _records = records;
        _specs = specs;
    }
    
    public LegacyRecordSpec? GetSpec(LegacyRecord record, string key, string unit)
    {
        var specs = _specs.Where(s => s.key == key && s.references.Contains(record.id) && s.unit == unit);
        LegacyRecordSpec? spec = specs.FirstOrDefault();
        return spec;
    }

    public int PlannedMinutes(LegacyRecord record)
    {
        var spec = GetSpec(record, "YT0x235", "seconds");
        if (spec == null)
        {
            return 0;
        }
        var siValue = spec.SiValue;
        return (int)Math.Round(siValue / 60, 0);
    }
    

    public List<Skill> Skills(LegacyRecord record)
    {
        var specs = _specs.Where(
            s => s.key == "YT0x267" && s.references.Contains(record.id));
        var skills = new List<Skill>();
        foreach (var spec in specs)
        {
            // TODO: this part should be in the LegacyConverter
            foreach (var description in  spec.description.Split(","))
            {
                if (Enum.TryParse(description, out Skill skill))
                {
                    skills.Add(skill);
                }
            }
        }

        return skills;
    }
}