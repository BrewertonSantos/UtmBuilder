using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

/// <summary>
/// A UTM management class of campaigns
/// </summary>
public class Campaign : ValueObject
{
    #region Public Constructors

    /// <summary>
    /// Generate a new campaign for a URL
    /// </summary>
    /// <param name="medium">Marketing medium (e.g. cpc, banner, email.</param>
    /// <param name="name">Product, promo code, or logan (e.g. spring_sale) one of campaign name or campaign id are required.</param>
    /// <param name="source">The referrer (e.g. google, newsletter).</param>
    /// <param name="id">The ads campaign id.</param>
    /// <param name="content">Use to differentiate ads.</param>
    /// <param name="term">Identify the paid keywords.</param>
    public Campaign(
        string medium,
        string name,
        string source,
        string? id = null,
        string? content = null,
        string? term = null)
    {
        Medium = medium;
        Name = name;
        Source = source;
        
        InvalidCampaignException.ThrowIfNull("Medium inválido.");
        InvalidCampaignException.ThrowIfNull("Name inválido.");
        InvalidCampaignException.ThrowIfNull("Source inválido.");
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Marketing medium (e.g. cpc, banner, email.
    /// </summary>
    public string Medium { get; }
    
    /// <summary>
    /// Product, promo code, or logan (e.g. spring_sale).
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The referrer (e.g. google, newsletter).
    /// </summary>
    public string Source { get; }
    
    /// <summary>
    /// The ads campaign id.
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Use to differentiate ads.
    /// </summary>
    public string? Content { get; set; }
    
    /// <summary>
    /// Identify the paid keywords.
    /// </summary>
    public string? Term { get; set; }

    #endregion
}