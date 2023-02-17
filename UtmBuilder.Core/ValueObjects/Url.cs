using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObject
{
    #region Private Properties

    private const string UrlRegexPattern =
        @"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    
    private const string UrlRegexPatternWithHttpProtocol =
        @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
        

    #endregion
    
    #region Public Constructors

    /// <summary>
    /// Create a new Uniform resource locator (URL)
    /// </summary>
    /// <param name="address">Address of URL</param>
    public Url(string address)
    {
        Address = address;

        if (Regex.IsMatch(Address, UrlRegexPattern) ||
            Regex.IsMatch(Address, UrlRegexPattern))
            throw new FormatException();
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Address of URL
    /// </summary>
    public string Address { get; }

    #endregion
}