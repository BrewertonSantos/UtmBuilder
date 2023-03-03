namespace UtmBuilder.Core.Entities;

/// <summary>
/// A abstract class to aggregate entity data
/// </summary>
public abstract class Entity
{
    #region Public Constructors

    /// <summary>
    /// Create a new entity with a new address
    /// </summary>
    public Entity() => Id = new Guid();

    #endregion

    #region Public Properties

    /// <summary>
    /// Entity's global unique identifier
    /// </summary>
    public Guid Id { get; }

    #endregion
}