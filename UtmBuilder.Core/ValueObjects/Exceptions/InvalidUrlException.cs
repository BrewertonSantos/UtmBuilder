using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Exceptions;

/// <summary>
/// Throw a invalid URL exception
/// </summary>
public class InvalidUrlException : Exception
{
    #region Private Properties

    private const string DefaultErrorMessage = "Invalid URL.";

    private const string UrlRegexPattern =
        @"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";

    private const string UrlRegexPatternWithHttpProtocol = @$"https?:\/\/(www\.)?{UrlRegexPattern}";

    #endregion

    #region Public Constructors

    /// <summary>
    /// Throw a new instance of invalid URL exception
    /// </summary>
    /// <param name="message">Text to be sent in exception details</param>
    public InvalidUrlException(string message = DefaultErrorMessage) : base(message)
    {
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Throw a invalid URL exception if address dont matches with URL regex patterns
    /// </summary>
    /// <param name="address">Uniform resource locator address</param>
    /// <param name="message">Exception message that be threw</param>
    /// <exception cref="InvalidUrlException"></exception>
    public static void ThrowIfInvalidUrl(
        string address,
        string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException(address);

        if (!Regex.IsMatch(address, UrlRegexPatternWithHttpProtocol)
            || !Regex.IsMatch(address, UrlRegexPattern))
            throw new InvalidUrlException();
    }

    #endregion
}