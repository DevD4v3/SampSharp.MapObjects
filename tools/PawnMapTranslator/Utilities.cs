namespace PawnMapTranslator;

public static class Utilities
{
    public static string ToFloat(string value)
    {
        value = value.Trim();

        if (value.EndsWith("f"))
            return value;

        return value + "f";
    }
}
