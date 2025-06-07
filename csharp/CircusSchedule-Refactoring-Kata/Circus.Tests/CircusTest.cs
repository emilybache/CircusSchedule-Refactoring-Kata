using Circus.Legacy;

namespace Circus.Tests;

public class CircusTest
{
    [Test]
    public void GetSpec()
    {
        var legacyShow = LegacyTestData.CreateTestShow();
        LegacyRecordList legacyList = new LegacyRecordList(legacyShow);
        var util = new LegacyUtil(legacyList, LegacyTestData.CreateTestSpecs());

        var spec = util.GetSpec(LegacyTestData.Juggler, "YT0x235", "seconds");

        Assert.That(spec.SiValue, Is.EqualTo(3 * 60));
    }

    [Test]
    public Task LegacyClassesCanBeConverted()
    {
        var legacyShow = LegacyTestData.CreateTestShow();
        LegacyRecordList legacyList = new LegacyRecordList(legacyShow);
        var converter = new LegacyConverter(new LegacyUtil(legacyList, LegacyTestData.CreateTestSpecs()));

        var result = converter.Convert(legacyList);

        return Verify(result);
    }
    
    [Test]
    public void FindAct()
    {
        var legacyShow = LegacyTestData.CreateTestShow();
        LegacyRecordList legacyList = new LegacyRecordList(legacyShow);
        var util = new LegacyUtil(legacyList, LegacyTestData.CreateTestSpecs());
        var services = new ShowServices(legacyShow, util);

        var task = services.FindAct("21","12");

        Assert.That(task.id, Is.EqualTo("12"));
    }
    
}