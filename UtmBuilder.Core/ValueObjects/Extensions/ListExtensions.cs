namespace UtmBuilder.Core.ValueObjects.Extensions;

/// <summary>
/// Extension methods to determinate lists behaviors
/// </summary>
public static class ListExtensions
{
    #region Public Methods

    /// <summary>
    /// Check if a key have value before add.
    /// </summary>
    /// <param name="list">String list to be used.</param>
    /// <param name="key">Item tag</param>
    /// <param name="value">Item value</param>
    public static void AddIfNotNull(
        this List<string> list,
        string key,
        string? value)
    {
        if (!string.IsNullOrEmpty(value))
            list.Add($"{key}={value}");
    }

    #endregion
}