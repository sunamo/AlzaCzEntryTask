
using AlzaCzEntryTask.Data.Request;
using Asp.Versioning;

namespace AlzaCzEntryTask.Controllers;

/// <summary>
/// Endpoints for manage Products
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController(AlzaCzEntryTaskDbContext db, ILogger logger) : ControllerBase
{
    /// <summary>
    /// Returns all products
    /// </summary>
    /// <remarks>
    /// Sample request body:
    /// 
    ///     GET /api/v1/Products
    /// 
    /// Sample response body:
    /// 
    ///     [
    ///			{
    ///			  "id": "0bddfb1a-031c-4273-a06e-1a000cfc6b9b",
    ///			  "name": "AlzaPower Garnet 10000mAh Power Delivery (22,5W) černá",
    ///			  "imgUri": "[Url with protocol]",
    ///			  "price": 699,
    ///			  "description": ""
    ///			},
    ///			...
    ///		]
    /// </remarks>
    /// <returns></returns>
    [HttpGet("")]
    [SwaggerOperation("Returns all products, with pagination")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all products, with pagination")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "See message")]
    public async Task<IActionResult> GetProducts(int pageNumberFrom1 = 1, int pageSize = 10, CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            var list = await db.Products.ToListAsync(cancellationToken);
            return Ok(list.Skip((pageNumberFrom1 - 1) * pageSize).Take(pageSize));
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Updates the description.
    /// </summary>
    /// <remarks>
    /// Sample request body:
    /// 
    /// 	{
    /// 	  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    /// 	  "description": "string"
    /// 	}
    ///
    /// Sample request response:
    /// 
    ///     200 OK
    /// 
    /// </remarks>
    /// <param name="request">Input data</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    [HttpPatch("Description")]
    [SwaggerOperation("Update description for product")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns all products, with pagination")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "See message")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "See message")]
    [SwaggerResponse(StatusCodes.Status415UnsupportedMediaType, "Empty request data")]
    public async Task<IActionResult> UpdateDescription(UpdateDescriptionRequest request, CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            var id = request.Id;
            var product = await db.Products.FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
            if (product == null)
            {
                return BadRequest(new ProblemDetails { Detail = $"Product with ID {id} was not found!", Status = 400 });
            }
            product.Description = request.Description;
            await db.SaveChangesAsync(cancellationToken);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return Problem(ex.Message);
        }
    }
}