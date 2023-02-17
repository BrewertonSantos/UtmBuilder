namespace UtmBuilder.Core.Entities;

public abstract class Entity
{
    #region Public Constructors

    public Entity() => Id = new Guid();

    #endregion

    #region Public Properties

    public Guid Id { get; }

    #endregion
}