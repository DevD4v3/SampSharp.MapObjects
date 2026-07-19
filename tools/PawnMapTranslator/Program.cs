var inputDirectory = "maps";
var outputDirectory =  "generated";

if (!Directory.Exists(inputDirectory))
{
    Console.WriteLine($"Input directory '{inputDirectory}' does not exist.");
    return;
}

Directory.CreateDirectory(outputDirectory);
var files = Directory.GetFiles(
    inputDirectory,
    "*.pwn",
    SearchOption.TopDirectoryOnly
);

Console.WriteLine($"Found {files.Length} map(s).");

foreach (var file in files)
{
    try
    {
        Translate(file);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Failed: {Path.GetFileName(file)}");
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}

Console.WriteLine();
Console.WriteLine("Done.");

return;

void Translate(string pawnFile)
{
    var source = File.ReadAllText(pawnFile, Encoding.UTF8);
    var mapName = Path.GetFileNameWithoutExtension(pawnFile);
    var generated = PawnTranslator.Translate(mapName, source);
    var outputFile = Path.Combine(outputDirectory, mapName + ".cs");

    File.WriteAllText(outputFile, generated, Encoding.UTF8);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Generated {mapName}.cs");
    Console.ResetColor();
}
