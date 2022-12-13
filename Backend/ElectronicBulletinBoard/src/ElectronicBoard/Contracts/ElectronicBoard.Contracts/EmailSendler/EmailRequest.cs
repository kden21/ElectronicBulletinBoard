namespace ElectronicBoard.Contracts.EmailSendler;

/// <summary>
/// Данные для отправки письма с подтверждением почты.
/// </summary>
public class EmailRequest
{
   /// <summary>
   /// Почта пользователя.
   /// </summary>
   public string ReceiverMail { get; set; }
   
   /// <summary>
   /// Имя пользователя.
   /// </summary>
   public string ReceiverName { get; set; }
}