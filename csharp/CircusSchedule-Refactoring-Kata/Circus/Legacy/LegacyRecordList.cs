namespace Circus.Legacy;

public class LegacyRecordList
{
    private LegacyRecord[] records;

    public LegacyRecordList(params LegacyRecord[] records)
    {
        this.records = records;
    }

    public int Count()
    {
        return records.Length;
    }

    public LegacyRecord Item(int index)
    {
        return records[index];
    }
}