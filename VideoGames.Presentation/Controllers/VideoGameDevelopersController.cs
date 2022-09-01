namespace VideoGames.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VideoGameDevelopersController : ControllerBase
{
    private readonly IVideoGameDevelopersService _videoGameDevelopersService;

    public VideoGameDevelopersController(
        IVideoGameDevelopersService videoGameDevelopersService) =>
        _videoGameDevelopersService = videoGameDevelopersService;

    /// <summary>
    /// Get video game developers.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGameDevelopers
    ///
    /// </remarks>
    /// <returns>Return all developers.</returns>
    /// <response code="200">Developers list.</response>
    [Tags(tags: "Developers")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGameDeveloperEntity>>> GetList()
    {
        var result = await _videoGameDevelopersService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get video game developer by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGameDevelopers/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Video game developer.</returns>
    /// <response code="200">Video game developer.</response>
    /// <response code="404">If the video game developer was not found.</response>
    [Tags(tags: "Developers")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var developer = await _videoGameDevelopersService.GetAsync(id);

        return developer.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Create video game developer.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /VideoGameDevelopers
    ///     {
    ///         "name": "Kefir"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Developers")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VideoGameDeveloperEntity>> Create(
        [FromBody] VideoGameDeveloperEntity dev)
    {
        await _videoGameDevelopersService.CreateAsync(entity: dev);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = dev?.Id },
            value: dev);
    }

    /// <summary>
    /// Update video game developer.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /VideoGameDevelopers
    ///     {
    ///         "id": Guid,
    ///         "name": "Kefir"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Developers")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VideoGameDeveloperEntity user)
    {
        await _videoGameDevelopersService.UpdateAsync(entity: user);

        return NoContent();
    }

    /// <summary>
    /// Delete video game developer.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /VideoGameDevelopers/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Developers")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _videoGameDevelopersService.DeleteAsync(id);

        return NoContent();
    }
}