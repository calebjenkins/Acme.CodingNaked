
namespace BDD_Specs.StepDefinitions;

public static class EnumExtension
{
    public static T? Parse<T>(this string value, bool ignoreCase = false) where T : struct
    {
        var match = Enum.TryParse<T>(value, ignoreCase, out var En);
        return (match ? (T?)En : null);
    }
}