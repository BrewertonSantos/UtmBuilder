using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core.Entities;

/// <summary>
/// Urchin traffic monitor
/// </summary>
public class Utm : Entity
{
    #region Public Constructors

    /// <summary>
    /// Create a new UTM
    /// </summary>
    /// <param name="url">A link address to access the content</param>
    /// <param name="campaign">A campaign used to tracker data</param>
    public Utm(
        Url url,
        Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }

    #endregion
    
    #region Public Properties

    /// <summary>
    /// Uniform resource locator
    /// </summary>
    public Url Url { get; }
    
    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; }
    
    #endregion

    #region Overloads

    /// <summary>
    /// Overrides a ToString method to return an url based in the campaign information.
    /// </summary>
    /// <returns>Return an full link address with campaign informations</returns>
    public override string ToString()
    {
        var segments = new List<string>();
        
        segments.AddIfNotNull("utm_campaign", Campaign.Content);
        segments.AddIfNotNull("utm_Id", Campaign.Id);
        segments.AddIfNotNull("utm_medium", Campaign.Medium);
        segments.AddIfNotNull("utm_campaign", Campaign.Name);
        segments.AddIfNotNull("utm_source", Campaign.Source);
        segments.AddIfNotNull("utm_term", Campaign.Term);
        
        return $"{Url.Address}?{string.Join("&", segments)}";
    }

    /// <summary>
    /// Implicitly converts a UTM to string.
    /// </summary>
    /// <param name="utm">Urchin traffic monitor (UTM).</param>
    /// <returns>Return an URL formed by the UTM properties</returns>
    public static implicit operator string(Utm utm) => utm.ToString();

    /// <summary>
    /// Implicitly converts a url string to urchin traffic monitor (UTM).
    /// </summary>
    /// <param name="link">URL address string.</param>
    /// <returns>Returns a UTM object.</returns>
    /// <exception cref="InvalidUrlException">Throw an invalid url exception when the link don't have segments.</exception>
    public static implicit operator Utm(string link)
    {
        if (string.IsNullOrEmpty(link))
            throw new InvalidUrlException();

        var url = new Url(link);
        var segments = url.Address.Split("?");
        if (segments.Length == 1)
            throw new InvalidUrlException("No segments were provided.");
        
        //TODO: Refactor this
        var pars= segments[1].Split("&");
        var content = pars.Where(content => content.StartsWith("utm_content")).FirstOrDefault().Split("=")[1];
        var id = pars.Where(id => id.StartsWith("utm_id")).FirstOrDefault().Split("=")[1];
        var medium = pars.Where(medium => medium.StartsWith("utm_medium")).FirstOrDefault().Split("=")[1];
        var name = pars.Where(name => name.StartsWith("utm_campaign")).FirstOrDefault().Split("=")[1];
        var source = pars.Where(source => source.StartsWith("utm_source")).FirstOrDefault().Split("=")[1];
        var term = pars.Where(term => term.StartsWith("term")).FirstOrDefault().Split("=")[1];

        return new Utm(new Url(segments[0]), new Campaign(content, id, medium, name, source, term));
    }

    #endregion
}