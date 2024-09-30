namespace AlzaCzEntryTask.Data.Request;

/// <summary>
/// Data class pro ProductsController/UpdateDescription
/// </summary>
public class UpdateDescriptionRequest
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; } = Guid.Empty;
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; set; } = string.Empty;
}
