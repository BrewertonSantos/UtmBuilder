namespace UtmBuilder.Core.ValueObjects.Exceptions;

/// <summary>
/// Throw a invalid Campaign exception
/// </summary>
public class InvalidCampaignException : Exception
{
    #region Private Properties

    private const string DefaultErrorMessage = "Invalid campaign parameters";

    #endregion

    #region Public Constructors

    /// <summary>
    /// Throw a new instance of invalid Campaign exception
    /// </summary>
    /// <param name="message">Text to be sent in exception details</param>
    public InvalidCampaignException(
        string message = DefaultErrorMessage) : base(message)
    {
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Throw a invalid Campaign exception if this don't have value
    /// </summary>
    /// <param name="item">A nullable string typed property</param>
    /// <param name="message">Exception message that be threw</param>
    /// <exception cref="InvalidCampaignException"></exception>
    public static void ThrowIfNull(
        string? item,
        string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(item))
            throw new InvalidCampaignException(message);
    }

    #endregion
}