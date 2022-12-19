using ElectronicBoard.Contracts.EmailSendler;

namespace ElectronicBoard.AppServices.EmailSendler;

/// <summary>
/// Сервис рассылки сообщений.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Отправляет сообщения с кодом для подтверждения почты.
    /// </summary>
    /// <param name="receiverMail">E-mail пользователя.</param>
    /// <param name="receiverName">Имя пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Код подтверждения.</returns>
    public  Task<int> EmailSendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation);
    
    /// <summary>
    /// Отправляет сообщение с кодом для смены пароля.
    /// </summary>
    /// <param name="receiverMail">Электронная почта пользователя.</param>
    /// <param name="receiverName">Имя пользователя.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns>Код подтверждения.</returns>
    public Task<int> PasswordRecoverySendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation);
    
    /// <summary>
    /// Отправляет на почту техподдержки обращение пользователя.
    /// </summary>
    /// <param name="request">Данные обращения <see cref="EmailFeedBackRequest"/></param>
    /// <param name="cancellationToken">Маркер отмены.</param>
    public Task EmailFeedBack(EmailFeedBackRequest request, CancellationToken cancellationToken);
}