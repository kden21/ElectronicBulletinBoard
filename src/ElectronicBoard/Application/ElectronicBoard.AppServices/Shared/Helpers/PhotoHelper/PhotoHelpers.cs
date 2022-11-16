namespace ElectronicBoard.AppServices.Shared.Helpers.PhotoHelper;

public static class PhotoHelpers
{
    public static string? ConvertToBase64(byte[]? photoBytesData)
    {
        if (photoBytesData == null)
            return null;
        return Convert.ToBase64String(photoBytesData);
    }

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