using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    #region Private Properties

    private const string InvalidUrl = "invalidUrl";
    private const string ValidUrl = "https://github.com/BrewertonSantos/";

    #endregion

    #region Public Methods

    [TestMethod]
    [TestCategory("URL Tests")]
    [ExpectedException(typeof(InvalidUrlException))]
    public Url ShouldReturnExceptionWhenUrlIsInvalid()
        => new Url(InvalidUrl);

    [TestMethod]
    [TestCategory("URL Tests")]
    public Url ShouldNotReturnExceptionWhenUrlIsValid()
        => new Url(ValidUrl);

    [TestMethod]
    [DataRow(" ", true)]
    [DataRow("http", true)]
    [DataRow(InvalidUrl, true)]
    [DataRow(ValidUrl, false)]
    public void TestUrl(
        string link,
        bool expectException)
    {
        if (expectException)
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch (InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }

    #endregion
}