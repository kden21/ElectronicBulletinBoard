using System.Net;
using ElectronicBoard.AppServices.Photo.Services;
using ElectronicBoard.Contracts.Photo;
using ElectronicBoard.Contracts.Shared.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicBoard.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v1/photos")]
public class PhotoController: ControllerBase
{
    private readonly ILogger<PhotoController> _logger;
    private readonly IPhotoService _photoService;

    public PhotoController(ILogger<PhotoController> logger, IPhotoService photoService)
    {
        _logger = logger;
        _photoService = photoService;
    }
    
    /// <summary>
    /// Возвращает фильтрованную коллекцию фото.
    /// </summary>
    /// <returns>Коллекция фото <see cref="PhotoDto"/>.</returns>
    [HttpGet("photoFilter",Name = "GetFilterPhotos")]
    [ProducesResponseType(typeof(IReadOnlyCollection<PhotoDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilterPhotos([FromQuery]PhotoFilterRequest photoFilter, CancellationToken cancellation)
    {
        return Ok(await _photoService.GetFilterPhotos(photoFilter, cancellation));
    }
    
    /// <summary>
    /// Возвращает коллекцию фото.
    /// </summary>
    /// <returns>Коллекция фото <see cref="PhotoDto"/>.</returns>
    [HttpGet(Name = "GetPhotos")]
    [ProducesResponseType(typeof(IReadOnlyCollection<PhotoDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllPhotos(CancellationToken cancellation)
    {
        return Ok(await _photoService.GetAllPhotos(cancellation));
    }
    
    /// <summary>
    /// Возвращает фото по Id.
    /// </summary>
    /// <param name="Id">Идентификатор.</param>
    /// <returns>Фото <see cref="PhotoDto"/>.</returns>
    [HttpGet("{photoId:int}", Name = "GetPhotoById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(PhotoDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int photoId, CancellationToken cancellation)
    {
        return Ok(await _photoService.GetPhotoById(photoId, cancellation));
    }

    /// <summary>
    /// Добавляет новое фото.
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreatePhoto")]
    [ProducesResponseType(typeof(PhotoDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreatePhoto([FromBody] PhotoDto model, CancellationToken cancellation)
    {
        model = await _photoService.CreatePhoto(model, cancellation);
        return CreatedAtAction("GetById", new { photoId = model.Id }, model);
    }
    
    /// <summary>
    /// Обновляет данные фото.
    /// </summary>
    /// <param name="photoId">Идентификатор пользователя.</param>
    /// <param name="photoDto">Пользователь.</param>
    [Authorize]
    [HttpPut("{photoId:int}", Name = "UpdatePhoto")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update(int photoId, [FromBody]PhotoDto photoDto, CancellationToken cancellation)
    {
        await _photoService.UpdatePhoto(photoId, photoDto, cancellation);
        return Ok();
    }
    
    /// <summary>
    /// Удаляет фото.
    /// </summary>
    /// <param name="photoId">Идентификатор пользователя.</param>
    [Authorize]
    [HttpDelete("{photoId:int}", Name = "DeletePhoto")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int photoId, CancellationToken cancellation)
    {
        await _photoService.DeletePhoto(photoId, cancellation);
        return NoContent();
    }
    
    /*/// <summary>
    /// Изменяет статус пользователя на неактивный профиль.
    /// </summary>
    /// <param name="photoId">Идентификатор пользователя.</param>
    [Authorize]
    [HttpDelete("{photoId:int}", Name = "DeletePhoto")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int photoId, CancellationToken cancellation)
    {
        await _photoService.SoftDeletePhoto(photoId, cancellation);
        return NoContent();
    }*/
}