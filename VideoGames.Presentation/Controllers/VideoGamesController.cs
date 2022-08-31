namespace VideoGames.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VideoGamesController : ControllerBase
{
    private readonly IVideoGamesService _videoGamesService;

    public VideoGamesController(
        IVideoGamesService videoGamesService) =>
        _videoGamesService = videoGamesService;

    /// <summary>
    /// Get video games.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGames
    ///
    /// </remarks>
    /// <returns>Return all games.</returns>
    /// <response code="200">Games list.</response>
    [Tags(tags: "Video games")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGameEntity>>> GetList()
    {
        var result = await _videoGamesService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get video games by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGames/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Video games.</returns>
    /// <response code="200">Video games.</response>
    /// <response code="404">If the video game was not found.</response>
    [Tags(tags: "Video games")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<VideoGameEntity>> Get(Guid id)
    {
        var result = await _videoGamesService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create video game.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /VideoGames
    ///     {
    ///         "name": "Quake"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Video games")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VideoGameEntity>> Create(
        [FromBody] VideoGameEntity game)
    {
        await _videoGamesService.CreateAsync(entity: game);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = game?.Id },
            value: game);
    }

    /// <summary>
    /// Update video game.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /VideoGames
    ///     {
    ///         "id": Guid,
    ///         "name": "Quake"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Video games")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VideoGameEntity user)
    {
        await _videoGamesService.UpdateAsync(entity: user);

        return NoContent();
    }

    /// <summary>
    /// Delete video game.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /VideoGames/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Video games")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _videoGamesService.DeleteAsync(id);

        return NoContent();
    }
}