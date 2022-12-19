namespace ElectronicBoard.AppServices.Shared.Helpers.CodeGeneratorHelper;

/// <summary>
/// Хелпер для генерации четырехзначного кода
/// </summary>
public static class CodeGeneratorHelper
{
    /// <summary>
    /// Возвращает четырехзначный код.
    /// </summary>
    /// <returns>Четырехзначный код<see cref="int"/>.</returns>
    public static int GetMailVerificationCode()
    {
        Random rnd = new Random();
        return rnd.Next(1000,10000);
    }
}