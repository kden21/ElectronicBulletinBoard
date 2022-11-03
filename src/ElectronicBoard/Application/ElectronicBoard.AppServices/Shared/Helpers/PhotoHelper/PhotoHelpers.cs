namespace ElectronicBoard.AppServices.Shared.Helpers.PhotoHelper;

public static class PhotoHelpers
{
    public static string? ConvertToBase64(byte[]? photoBytesData)
    {
        if (photoBytesData == null)
            return null;
        return Convert.ToBase64String(photoBytesData);
    }

    public static byte[]? ConvertToBytes(string stringInBase64)
    {
        byte[] photoBytesData = System.Convert.FromBase64String(stringInBase64);
        return photoBytesData;
    }
}