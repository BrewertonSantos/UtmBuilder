using UtmBuilder.Core.Entities;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests
{
    #region Private Properties

    private readonly Campaign _campaign = new (
        "medium",
        "name",
        "source",
        "id",
        "content",
        "term");
    
    private const string _result = $"https://github.com/BrewertonSantos/?" +
                                   $"utm_content=content&" +
                                   $"utm_id=id&" +
                                   $"utm_medium=medium&" +
                                   $"utm_campaign=name&" +
                                   $"utm_source=source&" +
                                   $"utm_term=term";
    
    private readonly Url _validUrl = new("https://github.com/BrewertonSantos/");

    #endregion
    
    [TestCategory("UTMTests")]
    [TestMethod]
    public void ShouldReturnUrlFromUtm()
    {
        var utm = new Utm(_campaign, _validUrl);
        Assert.AreEqual(_result, utm.ToString());
        Assert.AreEqual(_result, (string)utm);
    }
    
    [TestCategory("UTMTests")]
    [TestMethod]
    public void ShouldReturnUtmFromUrl()
    {
        var utm = new Utm(_campaign, _validUrl);
        
        Assert.AreEqual(_campaign.Medium, utm.Campaign.Medium);
        Assert.AreEqual(_campaign.Name, utm.Campaign.Name);
        Assert.AreEqual(_campaign.Source, utm.Campaign.Source);
        Assert.AreEqual(_campaign.Id, utm.Campaign.Id);
        Assert.AreEqual(_campaign.Content, utm.Campaign.Content);
        Assert.AreEqual(_campaign.Term, utm.Campaign.Term);
        
        Assert.AreEqual(_validUrl.Address, utm.Url.Address);
    }
}