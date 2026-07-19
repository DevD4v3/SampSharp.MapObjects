namespace PawnMapTranslator;

public static class ArgumentSplitter
{
    public static List<string> Split(string arguments)
    {
        List<string> result = [];

        var builder = new StringBuilder();

        bool insideString = false;

        foreach (char c in arguments)
        {
            switch (c)
            {
                case '"':
                    insideString = !insideString;
                    builder.Append(c);
                    break;

                case ',' when !insideString:
                    result.Add(builder.ToString().Trim());
                    builder.Clear();
                    break;

                default:
                    builder.Append(c);
                    break;
            }
        }

        if (builder.Length > 0)
            result.Add(builder.ToString().Trim());

        return result;
    }
}
