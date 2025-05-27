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
    public Task ConvertArtistOneSkill()
    {
        var legacyArtists = LegacyTestData.CreateTestArtists();
        LegacyRecordList legacyList = new LegacyRecordList(legacyArtists);
        var converter = new LegacyConverter(new LegacyUtil(legacyList, LegacyTestData.CreateTestSpecs()));
        var artist1 = legacyArtists[0];

        var result1 = converter.ConvertArtist(artist1);

        return Verify(result1);
    }
    
    [Test]
    public Task ConvertArtistMultiSkill()
    {
        var legacyArtists = LegacyTestData.CreateTestArtists();
        LegacyRecordList legacyList = new LegacyRecordList(legacyArtists);
        var converter = new LegacyConverter(new LegacyUtil(legacyList, LegacyTestData.CreateTestSpecs()));
        
        var result4 = converter.ConvertArtist(legacyArtists[4]);

        return Verify(result4);
    }
    
}