namespace AlzaCzEntryTask.Services.Swagger;


/// <summary>
/// Data class to store data from appsettings.json
/// </summary>
public class SwaggerConfig
{
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>
    /// The title.
    /// </value>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contact email.
    /// </summary>
    /// <value>
    /// The contact email.
    /// </value>
    public string ContactEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the contact.
    /// </summary>
    /// <value>
    /// The name of the contact.
    /// </value>
    public string ContactName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contact URL.
    /// </summary>
    /// <value>
    /// The contact URL.
    /// </value>
    public string ContactUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the license.
    /// </summary>
    /// <value>
    /// The name of the license.
    /// </value>
    public string LicenseName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the license URL.
    /// </summary>
    /// <value>
    /// The license URL.
    /// </value>
    public string LicenseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the route prefix.
    /// </summary>
    /// <value>
    /// The route prefix.
    /// </value>
    public string RoutePrefix { get; set; } = string.Empty;
}