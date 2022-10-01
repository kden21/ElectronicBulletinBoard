using System.Net;
using ElectronicBoard.AppServices.Services.Review;
using ElectronicBoard.AppServices.Services.Review.UserReview;
using ElectronicBoard.Contracts.Dto.Review;
using ElectronicBoard.Contracts.Filters.Review;
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
    [HttpGet(Name = "GetUserReviews")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserReviewDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserReviews([FromQuery]UserReviewFilterRequest userReviewFilter)
    {
        return Ok(await _userReviewService.GetAllUserReviews(userReviewFilter));
    }
    
    /// <summary>
    /// Возвращает отзыв по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Отзыв <see cref="UserReviewDto"/>.</returns>
    [HttpGet("{userReviewId:int}", Name = "GetUserReviewById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(UserReviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserReviewById(int userReviewId)
    {
        return Ok(await _userReviewService.GetUserReviewById(userReviewId));
    }

    /// <summary>
    /// Добавляет новый отзыв.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateUserReview")]
    [ProducesResponseType(typeof(UserReviewDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateUserReview([FromBody] UserReviewDto model)
    {
        model = await _userReviewService.CreateUserReview(model);
        return CreatedAtAction("GetUserReviewById", new { userReviewId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные отзыва.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    /// <param name="userReviewDto">Отзыв.</param>
    [HttpPut("{userReviewId:int}", Name = "UpdateUserReview")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateUserReview(int userReviewId, [FromBody]UserReviewDto userReviewDto)
    {
        await _userReviewService.UpdateUserReview(userReviewId, userReviewDto);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет отзыв.
    /// </summary>
    /// <param name="userReviewId">Идентификатор отзыва.</param>
    [HttpDelete("{userReviewId:int}", Name = "DeleteUserReview")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteUserReview(int userReviewId)
    {
        await _userReviewService.DeleteUserReview(userReviewId);
        return NoContent();
    }
}