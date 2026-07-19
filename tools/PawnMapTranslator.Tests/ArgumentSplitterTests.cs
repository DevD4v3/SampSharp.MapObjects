namespace PawnMapTranslator.Tests;

public class ArgumentSplitterTests
{
    [Test]
    public void Split_WhenArgumentsContainQuotedStrings_ShouldIgnoreCommasInsideQuotes()
    {
        // Arrange
        const string arguments = """0, 10357, "tvtower,sfs", "ws,transmit,red", 0xFFFFFFFF""";
        string[] expected =
        [
            "0",
            "10357",
            "\"tvtower,sfs\"",
            "\"ws,transmit,red\"",
            "0xFFFFFFFF"
        ];
        

        // Act
        List<string> actual = ArgumentSplitter.Split(arguments);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Split_WhenArgumentsContainWhitespace_ShouldTrimEachArgument()
    {
        // Arrange
        const string arguments = """  6989  ,   -166.94000   ,   138.17999   ,   -79.50000  """;
        string[] expected = 
        [
            "6989",
            "-166.94000",
            "138.17999",
            "-79.50000"
        ];

        // Act
        List<string> actual = ArgumentSplitter.Split(arguments);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Split_WhenArgumentsDoNotContainQuotedStrings_ShouldSplitByComma()
    {
        // Arrange
        const string arguments = """6989,-166.94000,138.17999,-79.50000,0.00000,0.00000,-17.46000""";
        string[] expected =
        [
            "6989",
            "-166.94000",
            "138.17999",
            "-79.50000",
            "0.00000",
            "0.00000",
            "-17.46000"
        ];

        // Act
        List<string> actual = ArgumentSplitter.Split(arguments);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Split_WhenSingleArgumentIsProvided_ShouldReturnSingleItem()
    {
        // Arrange
        const string arguments = "0xFFFFFFFF";
        string[] expected =
        [
            "0xFFFFFFFF"
        ];

        // Act
        List<string> actual = ArgumentSplitter.Split(arguments);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
