using System.Net;
using ElectronicBoard.AppServices.Services.Review.AdvtReview;
using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers.Review;

/// <summary>
/// Работа с отзывами <see cref="AdvtReviewDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/advtReviews")]
public class AdvtReviewController : ControllerBase
{
    private readonly ILogger<AdvtReviewController> _logger;
    private readonly IAdvtReviewService _advtReviewService;

    public AdvtReviewController(ILogger<AdvtReviewController> logger, IAdvtReviewService advtReviewService)
    {
        _logger = logger;
        _advtReviewService = advtReviewService;
    }
    
    /// <summary>
    /// Возвращает коллекцию отзывов.
    /// </summary>
    /// <returns>Коллекция отзывов <see cref="AdvtReviewDto"/>.</returns>
    [HttpGet(Name = "GetAdvtReviews")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvtReviewDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAdvtReviews([FromQuery]AdvtReviewFilterRequest advtReviewFilter, CancellationToken cancellation)
    {
        return Ok(await _advtReviewService.GetAllAdvtReviews(advtReviewFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает отзыв по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Отзыв <see cref="AdvtReviewDto"/>.</returns>
    [HttpGet("{advtReviewId:int}", Name = "GetAdvtReviewById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AdvtReviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAdvtReviewById(int advtReviewId, CancellationToken cancellation)
    {
        return Ok(await _advtReviewService.GetAdvtReviewById(advtReviewId, cancellation));
    }

    /// <summary>
    /// Добавляет новый отзыв.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost(Name = "CreateAdvtReview")]
    [ProducesResponseType(typeof(AdvtReviewDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateAdvtReview([FromBody] AdvtReviewDto model, CancellationToken cancellation)
    {
        model = await _advtReviewService.CreateAdvtReview(model, cancellation);
        return CreatedAtAction("GetAdvtReviewById", new { advtReviewId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    /// <param name="advtReviewDto">Отзыв.</param>
    [Authorize]
    [HttpPut("{advtReviewId:int}", Name = "UpdateAdvtReview")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAdvtReview(int advtReviewId, [FromBody]AdvtReviewDto advtReviewDto, CancellationToken cancellation)
    {
        await _advtReviewService.UpdateAdvtReview(advtReviewId, advtReviewDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    [Authorize]
    [HttpDelete("{advtReviewId:int}", Name = "DeleteAdvtReview")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAdvtReview(int advtReviewId, CancellationToken cancellation)
    {
        await _advtReviewService.DeleteAdvtReview(advtReviewId, cancellation);
        return NoContent();
    }
}