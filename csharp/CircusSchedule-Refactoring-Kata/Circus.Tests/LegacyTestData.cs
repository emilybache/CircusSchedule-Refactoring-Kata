using Circus.Legacy;

namespace Circus.Tests;

public class LegacyTestData
{
    public static LegacyRecord Juggler = new LegacyRecord("10", "Juggler", "Act", new LegacyRecordList());
    public static LegacyRecord Tightrope = new LegacyRecord("11", "Tightrope", "Act", new LegacyRecordList());
    public static LegacyRecord Trapeze = new LegacyRecord("12", "Trapeze", "Act", new LegacyRecordList());
    public static LegacyRecord Clown = new LegacyRecord("13", "Clown", "Act", new LegacyRecordList());
    public static LegacyRecord Mc = new LegacyRecord("14", "MC", "Act", new LegacyRecordList());

    public static LegacyRecord CreateTestShow()
    {
        var showPart1 = new LegacyRecord("20", "ShowPart1", "CircusShow",
            new LegacyRecordList(Juggler, Tightrope));
        var showPart2 = new LegacyRecord("21", "ShowPart2", "CircusShow",
            new LegacyRecordList(Trapeze, Clown));

        var acts = new LegacyRecordList(showPart1, Mc, showPart2);

        var show = new LegacyRecord("30", "2025-05-19, Paris", "Show", acts);

        return show;
    }

    public static LegacyRecord[] CreateTestArtists()
    {
        return new LegacyRecord[]
        {
            new LegacyRecord("50", "Marvin", "Artist", new LegacyRecordList()),
            new LegacyRecord("51", "Nils", "Artist", new LegacyRecordList()),
            new LegacyRecord("52", "Georg", "Artist", new LegacyRecordList()),
            new LegacyRecord("53", "Nicole", "Artist", new LegacyRecordList()),
            new LegacyRecord("54", "Emily", "Artist", new LegacyRecordList()),
        };
    }

    public static LegacyRecordSpec[] CreateTestSpecs()
    {
        return new[]
        {
            new LegacyRecordSpec("100", "YT0x267", "skills", ["50"], 0, "Juggling"),
            new LegacyRecordSpec("110", "YT0x267", "skills", ["51"], 0, "Juggling,Clowns"),
            new LegacyRecordSpec("120", "YT0x267", "skills", ["52"], 0, "Trapeze,Juggling,Tightrope"),
            new LegacyRecordSpec("130", "YT0x267", "skills", ["53"], 0, "Trapeze,Juggling,MC"),
            new LegacyRecordSpec("130", "YT0x267", "skills", ["54"], 0, "Trapeze,Tightrope,MC"),

            new LegacyRecordSpec("200", "YT0x235", "seconds", ["10"], 3 * 60, "plannedDuration"),
            new LegacyRecordSpec("210", "YT0x235", "seconds", ["11"], 7 * 60, "plannedDuration"),
            new LegacyRecordSpec("200", "YT0x235", "seconds", ["12"], 10 * 60, "plannedDuration"),
            new LegacyRecordSpec("210", "YT0x235", "seconds", ["13"], 6 * 60, "plannedDuration"),
            new LegacyRecordSpec("210", "YT0x235", "seconds", ["14"], 4 * 60, "plannedDuration"),
            
            new LegacyRecordSpec("300", "YT0x839", "seconds", ["10"], 1 * 60, "assignedDuration"),
            new LegacyRecordSpec("310", "YT0x839", "seconds", ["11"], 2 * 60, "assignedDuration"),
            new LegacyRecordSpec("310", "YT0x839", "seconds", ["12"], 6 * 60, "assignedDuration"),
            new LegacyRecordSpec("310", "YT0x839", "seconds", ["13"], 1 * 60, "assignedDuration"),
            new LegacyRecordSpec("310", "YT0x839", "seconds", ["14"], 2 * 60, "assignedDuration"),
        };
    }
}