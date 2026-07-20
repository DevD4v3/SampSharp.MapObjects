namespace PawnMapTranslator;

public static class PawnTranslator
{
    public static string Translate(string mapName, string source)
    {
        var builder = new StringBuilder();
        WriteHeader(builder, mapName);

        var variables = new Dictionary<string, string>();
        int objectIndex = 0;

        foreach (string rawLine in source.Split(
                     Environment.NewLine,
                     StringSplitOptions.RemoveEmptyEntries))
        {
            string line = rawLine.Trim();

            if (ShouldIgnore(line))
                continue;

            //--------------------------------------
            // objectId = CreateObject(...)
            //--------------------------------------

            if (line.Contains("= CreateObject("))
            {
                string pawnVariable =
                    line[..line.IndexOf('=')].Trim();

                string generatedVariable =
                    $"object{objectIndex++}";

                variables[pawnVariable] =
                    generatedVariable;

                string createObjectCall =
                    line[line.IndexOf("CreateObject(")..];

                builder.Append("        GlobalObject ");
                builder.Append(generatedVariable);
                builder.Append(" = ");
                builder.AppendLine(
                    TranslateCreateObject(createObjectCall));

                continue;
            }

            //--------------------------------------
            // CreateObject(...)
            //--------------------------------------

            if (line.StartsWith("CreateObject("))
            {
                builder.Append("        ");
                builder.AppendLine(
                    TranslateCreateObject(line));

                continue;
            }

            //--------------------------------------
            // SetObjectMaterial(...)
            //--------------------------------------

            if (line.StartsWith("SetObjectMaterial("))
            {
                builder.Append("        ");
                builder.AppendLine(
                    TranslateSetObjectMaterial(
                        line,
                        variables));

                continue;
            }

            //--------------------------------------
            // Not supported
            //--------------------------------------

            builder.AppendLine($"        // TODO: {line}");
        }

        WriteFooter(builder);

        return builder.ToString();
    }

    private static bool ShouldIgnore(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return true;

        return line.StartsWith("//")
            || line.StartsWith("/*")
            || line.StartsWith("*")
            || line.StartsWith("*/")
            || line.StartsWith("#")
            || line.StartsWith("public ")
            || line.StartsWith("forward ")
            || line.StartsWith("stock ")
            || line.StartsWith("native ")
            || line.StartsWith("new ")
            || line.StartsWith("return ")
            || line.StartsWith("{")
            || line.StartsWith("}");
    }

    private static void WriteHeader(StringBuilder builder, string mapName)
    {
        builder.AppendLine("namespace SampSharp.MapObjects.Definitions;");
        builder.AppendLine();
        builder.AppendLine($"internal sealed class {mapName} : MapDefinition");
        builder.AppendLine("{");
        builder.AppendLine($"    public override string Name => \"{mapName}\";");
        builder.AppendLine();
        builder.AppendLine("    protected override void OnLoad()");
        builder.AppendLine("    {");
    }

    private static void WriteFooter(StringBuilder builder)
    {
        builder.AppendLine("    }");
        builder.AppendLine("}");
    }

    private static string TranslateCreateObject(string line)
    {
        int endIndex = line.IndexOf(");");

        if (endIndex == -1)
        {
            throw new InvalidOperationException(
                "Expected ');' at the end of CreateObject call.");
        }

        var arguments = line["CreateObject(".Length..endIndex];
        var values = ArgumentSplitter.Split(arguments);
        if (values.Count is not (7 or 8))
        {
            throw new InvalidOperationException(
                $"CreateObject expects 7 or 8 arguments but received {values.Count}.");
        }

        var drawDistance = values.Count == 8
            ? $", drawDistance: {Utilities.ToFloat(values[7])}"
            : string.Empty;

        return
            $$"""
            CreateObject(modelId: {{values[0]}}, position: new Vector3({{Utilities.ToFloat(values[1])}}, {{Utilities.ToFloat(values[2])}}, {{Utilities.ToFloat(values[3])}}), rotation: new Vector3({{Utilities.ToFloat(values[4])}}, {{Utilities.ToFloat(values[5])}}, {{Utilities.ToFloat(values[6])}}){{drawDistance}});
            """;
    }

    private static string TranslateSetObjectMaterial(string line, Dictionary<string, string> variables)
    {
        int endIndex = line.IndexOf(");");

        if (endIndex == -1)
        {
            throw new InvalidOperationException(
                "Expected ');' at the end of SetObjectMaterial call.");
        }

        var arguments = line["SetObjectMaterial(".Length..endIndex];
        var values = ArgumentSplitter.Split(arguments);

        if (!variables.TryGetValue(values[0], out string variableName))
        {
            throw new InvalidOperationException(
                $"Object variable '{values[0]}' has not been declared.");
        }

        // Pawn SetObjectMaterial stores colors as ARGB.
        // SampSharp Color(int) expects RGBA, so we must explicitly convert from ARGB.
        return
            $$"""
            {{variableName}}.SetMaterial(materialIndex: {{values[1]}}, modelId: {{values[2]}}, txdName: {{values[3]}}, textureName: {{values[4]}}, materialColor: Color.FromInteger({{values[5]}}, ColorFormat.ARGB));
            """;
    }
}
