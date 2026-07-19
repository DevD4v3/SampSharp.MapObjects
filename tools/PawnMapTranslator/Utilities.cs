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

    public static string ToBool(string value)
    {
        value = value.Trim();

        return value switch
        {
            "0" => "false",
            "1" => "true",
            _ => throw new InvalidOperationException(
                $"'{value}' is not a valid Pawn boolean.")
        };
    }
}
