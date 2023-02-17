using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Entities;

public class Utm : Entity
{
    #region Public Constructors

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

    #region Overloads

    

    #endregion

    #endregion
}