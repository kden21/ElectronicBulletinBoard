using System.Net;
using ElectronicBoard.AppServices.Review.UserReview.Services;
using ElectronicBoard.Contracts.Review.UserReview.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers.Review;

/// <summary>
/// Работа с отзывами <see cref="UserReviewDto"/>.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("v1/userReviews")]
public class UserReviewController : ControllerBase
{ 
    private readonly ILogger<UserReviewController> _logger;
    private readonly IUserReviewService _userReviewService;

    public UserReviewController(ILogger<UserReviewController> logger, IUserReviewService userReviewService)
    {
        _logger = logger;
        _userReviewService = userReviewService;
    }
    
    /// <summary>
    /// Возвращает коллекцию отзывов.
    /// </summary>
    /// <returns>Коллекция отзывов <see cref="UserReviewDto"/>.</returns>
    [HttpGet("filter", Name = "GetFilterUserReviews")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserReviewDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterUserReviews([FromQuery]UserReviewFilterRequest userReviewFilter, CancellationToken cancellation)
    {
        return Ok(await _userReviewService.GetFilterUserReviews(userReviewFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает коллекцию отзывов.
    /// </summary>
    /// <returns>Коллекция отзывов <see cref="UserReviewDto"/>.</returns>
    [HttpGet(Name = "GetUserReviews")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserReviewDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllUserReviews(CancellationToken cancellation)
    {
        return Ok(await _userReviewService.GetAllUserReviews(cancellation));
    }
    
    /// <summary>
    /// Возвращает отзыв по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Отзыв <see cref="UserReviewDto"/>.</returns>
    [HttpGet("{userReviewId:int}", Name = "GetUserReviewById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(UserReviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserReviewById(int userReviewId, CancellationToken cancellation)
    {
        return Ok(await _userReviewService.GetUserReviewById(userReviewId, cancellation));
    }

    /// <summary>
    /// Добавляет новый отзыв.
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost(Name = "CreateUserReview")]
    [ProducesResponseType(typeof(UserReviewDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateUserReview([FromBody] UserReviewDto model, CancellationToken cancellation)
    {
        model = await _userReviewService.CreateUserReview(model, cancellation);
        return CreatedAtAction("GetUserReviewById", new { userReviewId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    /// <param name="userReviewDto">Отзыв.</param>
    [Authorize]
    [HttpPut("{userReviewId:int}", Name = "UpdateUserReview")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateUserReview(int userReviewId, [FromBody]UserReviewDto userReviewDto, CancellationToken cancellation)
    {
        await _userReviewService.UpdateUserReview(userReviewId, userReviewDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    [Authorize]
    [HttpDelete("{userReviewId:int}", Name = "DeleteUserReview")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteUserReview(int userReviewId, CancellationToken cancellation)
    {
        await _userReviewService.DeleteUserReview(userReviewId, cancellation);
        return NoContent();
    }
}