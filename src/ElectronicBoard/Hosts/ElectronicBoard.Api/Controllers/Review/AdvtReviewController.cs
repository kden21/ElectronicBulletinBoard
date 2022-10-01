using System.Net;
using ElectronicBoard.AppServices.Services.Review;
using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
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
    public async Task<IActionResult> GetAdvtReviews([FromQuery]AdvtReviewFilterRequest advtReviewFilter)
    {
        return Ok(await _advtReviewService.GetAllAdvtReviews(advtReviewFilter));
    }
    
    /// <summary>
    /// Возвращает отзыв по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Отзыв <see cref="AdvtReviewDto"/>.</returns>
    [HttpGet("{advtReviewId:int}", Name = "GetAdvtReviewById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AdvtReviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAdvtReviewById(int advtReviewId)
    {
        return Ok(await _advtReviewService.GetAdvtReviewById(advtReviewId));
    }

    /// <summary>
    /// Добавляет новый отзыв.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateAdvtReview")]
    [ProducesResponseType(typeof(AdvtReviewDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateAdvtReview([FromBody] AdvtReviewDto model)
    {
        model = await _advtReviewService.CreateAdvtReview(model);
        return CreatedAtAction("GetAdvtReviewById", new { advtReviewId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    /// <param name="advtReviewDto">Отзыв.</param>
    [HttpPut("{advtReviewId:int}", Name = "UpdateAdvtReview")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateAdvtReview(int advtReviewId, [FromBody]AdvtReviewDto advtReviewDto)
    {
        await _advtReviewService.UpdateAdvtReview(advtReviewId, advtReviewDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="advtReviewId">Идентификатор отзыва.</param>
    [HttpDelete("{advtReviewId:int}", Name = "DeleteAdvtReview")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteAdvtReview(int advtReviewId)
    {
        await _advtReviewService.DeleteAdvtReview(advtReviewId);
        return NoContent();
    }
}