using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

/// <summary>
/// Management of uniform resource locator properties
/// </summary>
public class Url : ValueObject
{
    #region Public Constructors

    /// <summary>
    /// Create a new Uniform resource locator (URL)
    /// </summary>
    /// <param name="address">Address of URL</param>
    public Url(string address)
    {
        Address = address;
        InvalidUrlException.ThrowIfInvalidUrl(address);
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Address of URL
    /// </summary>
    public string Address { get; }

    #endregion
}