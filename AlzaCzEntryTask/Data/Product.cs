
namespace AlzaCzEntryTask.Data;
/// <summary>
/// Entity class for EF
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Required]
    public string Name { get; set; } = "";
    /// <summary>
    /// Gets or sets the img URI.
    /// </summary>
    /// <value>
    /// The img URI.
    /// </value>
    [Required]
    public string ImgUri { get; set; } = "";
    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>
    /// The price.
    /// </value>
    [Required]
    public decimal Price { get; set; } = 0;
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; set; } = "";
}