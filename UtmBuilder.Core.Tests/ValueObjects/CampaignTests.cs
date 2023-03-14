using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class CampaignTests
{
    #region Public Methods

    [TestCategory("CampaignTests")]
    [TestMethod]
    [DataRow("", "", "", true)]
    [DataRow("", "", "src", true)]
    [DataRow("med", "", "src", true)]
    [DataRow("med", "nme", "src", false)]
    public void TestCampaign(
        string medium,
        string name,
        string source,
        bool expectException)
    {
        var action = ()
            => new Campaign(
                medium,
                name,
                source);

        if (expectException)
            Assert.ThrowsException<InvalidCampaignException>(action);
        else
            action.Invoke();
    }

    #endregion
}