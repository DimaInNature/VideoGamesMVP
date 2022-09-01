namespace VideoGames.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VideoGameGenresController : ControllerBase
{
    private readonly IVideoGameGenresService _videoGameGenresService;

    private readonly IVideoGamesService _videoGamesService;

    public VideoGameGenresController(
        IVideoGameGenresService videoGameGenresService,
        IVideoGamesService videoGamesService)
    {
        _videoGameGenresService = videoGameGenresService;

        _videoGamesService = videoGamesService;
    }

    /// <summary>
    /// Get video game genres.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGameGenres
    ///
    /// </remarks>
    /// <returns>Return all genres.</returns>
    /// <response code="200">Genres list.</response>
    [Tags(tags: "Genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGameGenreEntity>>> GetList()
    {
        var result = await _videoGameGenresService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get video game genre by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGameGenres/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Video game genre.</returns>
    /// <response code="200">Video game genre.</response>
    /// <response code="404">If the video game genre was not found.</response>
    [Tags(tags: "Genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var genre = await _videoGameGenresService.GetAsync(id);

        return genre.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Get video games by genre name.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VideoGameGenres/VideoGames/Action
    ///
    /// </remarks>
    /// <param name="name"> Genre name </param>
    /// <returns>Video games.</returns>
    /// <response code="200">Video games.</response>
    /// <response code="404">If the video game was not found.</response>
    [Tags(tags: "Genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "VideoGames/{name}")]
    public async Task<ActionResult<VideoGameEntity>> Get(string name)
    {
        var result = await _videoGamesService.GetAllAsync(name);

        return result.Any() ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create video game genre.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /VideoGameGenres
    ///     {
    ///         "name": "Strategy"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VideoGameGenreEntity>> Create(
        [FromBody] VideoGameGenreEntity genre)
    {
        await _videoGameGenresService.CreateAsync(entity: genre);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = genre?.Id },
            value: genre);
    }

    /// <summary>
    /// Update video game genre.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /VideoGameGenres
    ///     {
    ///         "id": Guid,
    ///         "name": "Strategy"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VideoGameGenreEntity user)
    {
        await _videoGameGenresService.UpdateAsync(entity: user);

        return NoContent();
    }

    /// <summary>
    /// Delete video game genre.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /VideoGameGenres/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _videoGameGenresService.DeleteAsync(id);

        return NoContent();
    }
}