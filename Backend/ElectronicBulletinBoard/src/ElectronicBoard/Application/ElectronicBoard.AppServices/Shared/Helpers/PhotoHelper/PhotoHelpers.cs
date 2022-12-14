namespace ElectronicBoard.AppServices.Shared.Helpers.PhotoHelper;

/// <summary>
/// Хелпер для работы с изображениями.
/// </summary>
public static class PhotoHelpers
{
    /// <summary>
    /// Конвертирует массив байтов в Base64 строку.
    /// </summary>
    /// <param name="photoBytesData"></param>
    /// <returns>Base64 строка <see cref="string"/></returns>
    public static string? ConvertToBase64(byte[] photoBytesData)
    {
        if (photoBytesData==null)
            return null;
        
        return Convert.ToBase64String(photoBytesData);
    }

    /// <summary>
    /// Конвертирует Base64 строку в массив байтов.
    /// </summary>
    /// <param name="stringInBase64"></param>
    /// <returns></returns>
    public static byte[]? ConvertToBytes(string? stringInBase64)
    {
        if (stringInBase64 == null)
            return null;
        else
        {
            stringInBase64 = stringInBase64.Remove(0, stringInBase64.IndexOf(',')+1);
            return  Convert.FromBase64String(stringInBase64);
            
        }
    }
}